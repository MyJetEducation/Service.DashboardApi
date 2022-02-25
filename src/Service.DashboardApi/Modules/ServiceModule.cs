using Autofac;
using Microsoft.Extensions.Logging;
using Service.Core.Client.Services;
using Service.DashboardApi.Services;
using Service.EducationProgress.Client;
using Service.EducationRetry.Client;
using Service.UserProgress.Client;
using Service.UserReward.Client;

namespace Service.DashboardApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterEducationRetryClient(Program.Settings.EducationRetryServiceUrl, Program.LogFactory.CreateLogger(typeof(EducationRetryClientFactory)));

            builder.RegisterEducationProgressClient(Program.Settings.EducationProgressServiceUrl);
            builder.RegisterUserProgressClient(Program.Settings.UserProgressServiceUrl);
            builder.RegisterUserRewardClient(Program.Settings.UserRewardServiceUrl);

            builder.RegisterType<RetryTaskService>().AsImplementedInterfaces().SingleInstance();
	        builder.RegisterType<SystemClock>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
