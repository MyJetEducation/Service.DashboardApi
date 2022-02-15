using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.DashboardApi.Settings
{
	public class SettingsModel
	{
		[YamlProperty("DashboardApi.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("DashboardApi.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("DashboardApi.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("DashboardApi.JwtAudience")]
		public string JwtAudience { get; set; }

		[YamlProperty("DashboardApi.UserInfoCrudServiceUrl")]
		public string UserInfoCrudServiceUrl { get; set; }

		[YamlProperty("DashboardApi.EducationProgressServiceUrl")]
		public string EducationProgressServiceUrl { get; set; }

		[YamlProperty("DashboardApi.UserRewardServiceUrl")]
		public string UserRewardServiceUrl { get; set; }

		[YamlProperty("DashboardApi.UserProgressServiceUrl")]
		public string UserProgressServiceUrl { get; set; }

		[YamlProperty("DashboardApi.EducationRetryServiceUrl")]
		public string EducationRetryServiceUrl { get; set; }
	}
}