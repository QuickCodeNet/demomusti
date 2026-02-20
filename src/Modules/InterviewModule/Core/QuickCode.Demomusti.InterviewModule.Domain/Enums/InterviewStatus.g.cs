using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demomusti.InterviewModule.Domain.Enums;

public enum InterviewStatus{
	[Description("Interview is scheduled")]
	Scheduled,
	[Description("Interview has been completed")]
	Completed,
	[Description("Interview has been cancelled")]
	Cancelled,
	[Description("Interview has been rescheduled")]
	Rescheduled
}
