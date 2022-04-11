using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.WalletApi.DashboardApi.Settings
{
	public class SettingsModel
	{
		[YamlProperty("WalletApiEducation.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("WalletApiEducation.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("WalletApiEducation.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("WalletApiEducation.EnableApiTrace")]
		public bool EnableApiTrace { get; set; }

		[YamlProperty("WalletApiEducation.MyNoSqlReaderHostPort")]
		public string MyNoSqlReaderHostPort { get; set; }

		[YamlProperty("WalletApiEducation.AuthMyNoSqlReaderHostPort")]
		public string AuthMyNoSqlReaderHostPort { get; set; }

		[YamlProperty("WalletApiEducation.SessionEncryptionKeyId")]
		public string SessionEncryptionKeyId { get; set; }

		[YamlProperty("WalletApiEducation.MyNoSqlWriterUrl")]
		public string MyNoSqlWriterUrl { get; set; }

		[YamlProperty("WalletApiEducation.EducationProgressServiceUrl")]
		public string EducationProgressServiceUrl { get; set; }

		[YamlProperty("WalletApiEducation.UserRewardServiceUrl")]
		public string UserRewardServiceUrl { get; set; }

		[YamlProperty("WalletApiEducation.UserProgressServiceUrl")]
		public string UserProgressServiceUrl { get; set; }

		[YamlProperty("WalletApiEducation.EducationRetryServiceUrl")]
		public string EducationRetryServiceUrl { get; set; }
	}
}