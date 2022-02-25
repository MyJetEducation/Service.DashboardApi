using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service.Core.Client.Constants;
using Service.DashboardApi.Mappers;
using Service.DashboardApi.Models;
using Service.DashboardApi.Services;
using Service.Education.Extensions;
using Service.EducationProgress.Grpc;
using Service.EducationProgress.Grpc.Models;
using Service.UserInfo.Crud.Grpc.Models;
using Service.UserProgress.Grpc;
using Service.UserProgress.Grpc.Models;
using Service.UserReward.Grpc;
using Service.UserReward.Grpc.Models;

namespace Service.DashboardApi.Controllers
{
	[Authorize]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	[SwaggerResponse(HttpStatusCode.Unauthorized, null, Description = "Unauthorized")]
	[Route("/api/v1/education/dashboard")]
	public class DashboardController : ControllerBase
	{
		private readonly IEducationProgressService _educationProgressService;
		private readonly IUserProgressService _userProgressService;
		private readonly IUserRewardService _userRewardService;
		private readonly IRetryTaskService _retryTaskService;

		public DashboardController(IEducationProgressService progressService,
			IUserProgressService userProgressService,
			IUserRewardService userRewardService,
			IRetryTaskService retryTaskService)
		{
			_educationProgressService = progressService;
			_userProgressService = userProgressService;
			_userRewardService = userRewardService;
			_retryTaskService = retryTaskService;
		}

		[HttpPost("tutorials")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<TutorialStateResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> GetTutorialListInfoAsync()
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			EducationStateProgressGrpcResponse educationStateProgressResponse = await _educationProgressService.GetEducationStateProgressAsync(new GetEducationStateProgressGrpcRequest
			{
				UserId = userId
			});

			return DataResponse<TutorialStateResponse>.Ok(educationStateProgressResponse.ToModel());
		}

		[HttpPost("tutorial")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<TutorialProgressResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> GetTutorialInfoAsync([FromBody] TutorialInfoRequest request)
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			TutorialEducationProgressGrpcResponse progressResponse = await _educationProgressService.GetTutorialProgressAsync(new GetTutorialEducationProgressGrpcRequest
			{
				UserId = userId,
				Tutorial = request.Tutorial
			});

			TutorialProgressResponse tutorialProgressResponse = progressResponse.ToModel();
			foreach (TutorialProgressUnitModel unit in tutorialProgressResponse.Units)
			{
				foreach (TutorialProgressTaskModel task in unit.Tasks)
				{
					int progressValue = task.TaskScore;
					bool lowProgress = !progressValue.IsMaxProgress();
					bool inRetryState = await _retryTaskService.TaskInRetryStateAsync(userId, unit.Unit, task.Task);
					bool canRetryTask = !inRetryState && lowProgress;

					task.Retry = new RetryInfo
					{
						InRetry = inRetryState,
						CanRetryByCount = canRetryTask && await _retryTaskService.HasRetryCountAsync(userId),
						CanRetryByTime = canRetryTask && await _retryTaskService.CanRetryByTimeAsync(userId, task.Date)
					};
				}
			}

			return DataResponse<TutorialProgressResponse>.Ok(tutorialProgressResponse);
		}

		[HttpPost("progress")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<ProgressResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> GetProgressAsync()
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			EducationProgressGrpcResponse progress = await _educationProgressService.GetProgressAsync(new GetEducationProgressGrpcRequest {UserId = userId});
			UnitedProgressGrpcResponse statsProgress = await _userProgressService.GetUnitedProgressAsync(new GetProgressGrpcRequset {UserId = userId});
			UserAchievementsGrpcResponse achievements = await _userRewardService.GetUserAchievementsAsync(new GetUserAchievementsGrpcRequest {UserId = userId});

			return DataResponse<ProgressResponse>.Ok(new ProgressResponse
			{
				TaskScore = (progress?.Value).GetValueOrDefault(),
				Habit = statsProgress.Habit.ToModel(),
				Skill = statsProgress.Skill.ToModel(),
				Achievements = achievements?.Items
			});
		}

		protected Guid? GetUserId() => Guid.TryParse(User.Identity?.Name, out Guid uid) ? (Guid?)uid : null;
	}
}