using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Service.Education.Structure;

namespace Service.DashboardApi.Models
{
	public class TutorialProgressResponse
	{
		public EducationTutorial Tutorial { get; set; }

		public bool Finished { get; set; }

		[Range(1, 100)]
		public int TaskScore { get; set; }

		[Range(1, 5)]
		public TutorialProgressUnitModel[] Units { get; set; }
	}

	public class TutorialProgressUnitModel
	{
		[Range(1, 5)]
		public int Unit { get; set; }

		public bool Finished { get; set; }

		[Range(1, 100)]
		public int TaskScore { get; set; }

		[DataMember(Order = 4)]
		public bool HasProgress { get; set; }

		[Range(1, 6)]
		public TutorialProgressTaskModel[] Tasks { get; set; }
	}

	public class TutorialProgressTaskModel
	{
		[Range(1, 6)]
		public int Task { get; set; }

		[Range(1, 100)]
		public int TaskScore { get; set; }

		public bool HasProgress { get; set; }

		public DateTime? Date { get; set; }

		public RetryInfo Retry { get; set; }
	}

	public class RetryInfo
	{
		public bool InRetry { get; set; }

		public bool CanRetryByTime { get; set; }

		public bool CanRetryByCount { get; set; }
	}
}