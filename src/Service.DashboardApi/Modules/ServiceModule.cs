using Autofac;
using Service.EducationProgress.Client;
using Service.EducationRetry.Client;
using Service.UserInfo.Crud.Client;
using Service.UserProgress.Client;
using Service.UserReward.Client;

namespace Service.DashboardApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterUserInfoCrudClient(Program.Settings.UserInfoCrudServiceUrl);
            builder.RegisterEducationProgressClient(Program.Settings.EducationProgressServiceUrl);
            builder.RegisterUserProgressClient(Program.Settings.UserProgressServiceUrl);
            builder.RegisterUserRewardClient(Program.Settings.UserRewardServiceUrl);
            builder.RegisterEducationRetryClient(Program.Settings.EducationRetryServiceUrl);
        }
    }
}
