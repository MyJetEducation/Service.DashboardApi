using System.ComponentModel.DataAnnotations;
using Service.Education.Structure;

namespace Service.WalletApi.DashboardApi.Controllers.Contracts
{
	public class TutorialInfoRequest
	{
		[Required]
		[Range(1, 9)]
		public EducationTutorial Tutorial { get; set; }
	}
}