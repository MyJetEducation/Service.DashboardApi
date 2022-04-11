using Autofac;
using Microsoft.Extensions.Logging;
using MyJetWallet.ApiSecurityManager.Autofac;
using MyJetWallet.Sdk.RestApiTrace;
using MyJetWallet.Sdk.Service;
using Service.Core.Client.Services;
using Service.EducationProgress.Client;
using Service.EducationRetry.Client;
using Service.UserProgress.Client;
using Service.UserReward.Client;
using Service.WalletApi.DashboardApi.Services;

namespace Service.WalletApi.DashboardApi.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterEncryptionServiceClient();

			builder.RegisterEducationRetryClient(Program.Settings.EducationRetryServiceUrl, Program.LoggerFactory.CreateLogger(typeof (EducationRetryClientFactory)));
			builder.RegisterEducationProgressClient(Program.Settings.EducationProgressServiceUrl);
			builder.RegisterUserProgressClient(Program.Settings.UserProgressServiceUrl);
			builder.RegisterUserRewardClient(Program.Settings.UserRewardServiceUrl);

			builder.RegisterType<RetryTaskService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<SystemClock>().AsImplementedInterfaces().SingleInstance();

			if (Program.Settings.EnableApiTrace)
			{
				builder
					.RegisterInstance(new ApiTraceManager(Program.Settings.ElkLogs, "api-trace",
						Program.LoggerFactory.CreateLogger("ApiTraceManager")))
					.As<IApiTraceManager>()
					.As<IStartable>()
					.AutoActivate()
					.SingleInstance();
			}
		}
	}
}