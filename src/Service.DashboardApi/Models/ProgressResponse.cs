using System.ComponentModel.DataAnnotations;
using Service.Core.Client.Constants;

namespace Service.DashboardApi.Models
{
	public class ProgressResponse
	{
		[Range(1, 100)]
		public int TaskScore { get; set; }

		[Range(0, 270)]
		public int Tasks { get; set; }

		public StatusProgressModel Habit { get; set; }

		[Range(1, 100)]
		public int SkillProgress { get; set; }

		[EnumDataType(typeof(UserAchievement))]
		public UserAchievement[] Achievements { get; set; }
	}

	public class StatusProgressModel
	{
		[Range(1, 9)]
		public int Index { get; set; }

		public int Count { get; set; }

		[Range(1, 100)]
		public int Progress { get; set; }
	}
}