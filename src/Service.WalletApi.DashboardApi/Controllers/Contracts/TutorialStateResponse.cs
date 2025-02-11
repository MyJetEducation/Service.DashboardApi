﻿using System.ComponentModel.DataAnnotations;
using Service.Education.Structure;

namespace Service.WalletApi.DashboardApi.Controllers.Contracts
{
	public class TutorialStateResponse
	{
		public TutorialStateModel[] Tutorials { get; set; }
	}

	public class TutorialStateModel
	{
		[EnumDataType(typeof (EducationTutorial))]
		public EducationTutorial Tutorial { get; set; }

		public bool Started { get; set; }

		public bool Finished { get; set; }
	}
}