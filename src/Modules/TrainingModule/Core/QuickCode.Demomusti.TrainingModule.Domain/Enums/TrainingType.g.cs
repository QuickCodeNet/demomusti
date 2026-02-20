using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demomusti.TrainingModule.Domain.Enums;

public enum TrainingType{
	[Description("Online training")]
	Online,
	[Description("In-person training")]
	InPerson,
	[Description("Workshop training")]
	Workshop
}
