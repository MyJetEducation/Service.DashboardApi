using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.WalletApi.DashboardApi.Settings
{
	public class SettingsModel
	{
		[YamlProperty("DashboardApi.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("DashboardApi.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("DashboardApi.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("DashboardApi.EnableApiTrace")]
		public bool EnableApiTrace { get; set; }

		[YamlProperty("DashboardApi.MyNoSqlReaderHostPort")]
		public string MyNoSqlReaderHostPort { get; set; }

		[YamlProperty("DashboardApi.AuthMyNoSqlReaderHostPort")]
		public string AuthMyNoSqlReaderHostPort { get; set; }

		[YamlProperty("DashboardApi.SessionEncryptionKeyId")]
		public string SessionEncryptionKeyId { get; set; }

		[YamlProperty("DashboardApi.MyNoSqlWriterUrl")]
		public string MyNoSqlWriterUrl { get; set; }

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