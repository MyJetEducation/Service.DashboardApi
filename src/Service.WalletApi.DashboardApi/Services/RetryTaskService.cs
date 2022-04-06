using System;
using System.Threading.Tasks;
using Service.Core.Client.Services;
using Service.Education.Structure;
using Service.EducationRetry.Grpc;
using Service.EducationRetry.Grpc.Models;
using Service.Grpc;

namespace Service.WalletApi.DashboardApi.Services
{
	public class RetryTaskService : IRetryTaskService
	{
		private readonly IGrpcServiceProxy<IEducationRetryService> _retryService;
		private readonly ISystemClock _systemClock;

		public RetryTaskService(IGrpcServiceProxy<IEducationRetryService> retryService, ISystemClock systemClock)
		{
			_retryService = retryService;
			_systemClock = systemClock;
		}

		public async ValueTask<bool> TaskInRetryStateAsync(string userId, int unit, int task)
		{
			TaskRetryStateGrpcResponse response = await _retryService.Service.GetTaskRetryStateAsync(new GetTaskRetryStateGrpcRequest
			{
				UserId = userId,
				Tutorial = EducationTutorial.PersonalFinance,
				Unit = unit,
				Task = task
			});

			return response.InRetry;
		}

		public async ValueTask<DateTime?> GetRetryLastDateAsync(string userId)
		{
			return (await _retryService.Service.GetRetryLastDateAsync(new GetRetryLastDateGrpcRequest
			{
				UserId = userId
			}))?.Date;
		}

		public bool CanRetryByTimeAsync(DateTime? progressDate, DateTime? lastRetryDate) => progressDate != null
			&& OneDayGone(progressDate.Value)
			&& (lastRetryDate == null || OneDayGone(lastRetryDate.Value));

		public async ValueTask<bool> HasRetryCountAsync(string userId)
		{
			RetryCountGrpcResponse retryResponse = await _retryService.Service.GetRetryCountAsync(new GetRetryCountGrpcRequest
			{
				UserId = userId
			});

			return retryResponse?.Count > 0;
		}

		private bool OneDayGone(DateTime date) => _systemClock.Now.Subtract(date).TotalDays >= 1;
	}
}