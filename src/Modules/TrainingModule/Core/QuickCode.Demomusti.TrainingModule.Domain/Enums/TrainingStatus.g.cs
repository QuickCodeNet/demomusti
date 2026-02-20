using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demomusti.TrainingModule.Domain.Enums;

public enum TrainingStatus{
	[Description("Training is planned")]
	Planned,
	[Description("Training is in progress")]
	InProgress,
	[Description("Training has been completed")]
	Completed,
	[Description("Training has been cancelled")]
	Cancelled
}
