using System.Linq;
using Service.DashboardApi.Models;
using Service.EducationProgress.Grpc.Models;
using Service.UserProgress.Grpc.Models;

namespace Service.DashboardApi.Mappers
{
	public static class StatusProgressMapper
	{
		public static TutorialProgressResponse ToModel(this TutorialEducationProgressGrpcResponse grpcResponse) => new TutorialProgressResponse
		{
			TaskScore = grpcResponse.TaskScore,
			Finished = grpcResponse.Finished,
			Tutorial = grpcResponse.Tutorial,
			Units = grpcResponse.Units.Select(response => response.ToModel()).ToArray()
		};

		public static TutorialProgressUnitModel ToModel(this ShortUnitEducationProgressGrpcResponse grpcModel) => new TutorialProgressUnitModel
		{
			Finished = grpcModel.Finished,
			TaskScore = grpcModel.TaskScore,
			HasProgress = grpcModel.HasProgress,
			Unit = grpcModel.Unit,
			Tasks = grpcModel.Tasks.Select(model => model.ToModel()).ToArray()
		};

		public static TutorialProgressTaskModel ToModel(this ShortTaskEducationProgressGrpcModel grpcModel) => new TutorialProgressTaskModel
		{
			TaskScore = grpcModel.TaskScore,
			HasProgress = grpcModel.HasProgress,
			Task = grpcModel.Task
		};

		public static TutorialStateResponse ToModel(this EducationStateProgressGrpcResponse grpcResponse) => new TutorialStateResponse
		{
			Tutorials = grpcResponse?.Tutorials.Select(model => model.ToModel()).ToArray()
		};

		public static TutorialStateModel ToModel(this EducationStateTutorialGrpcModel grpcModel) => new TutorialStateModel
		{
			Tutorial = grpcModel.Tutorial,
			Started = grpcModel.Started,
			Finished = grpcModel.Finished
		};

		public static StatusProgressModel ToModel(this ProgressGrpcResponse grpcResponse) => new StatusProgressModel
		{
			Count = grpcResponse.Count,
			Index = grpcResponse.Index,
			Progress = grpcResponse.Progress
		};
	}
}