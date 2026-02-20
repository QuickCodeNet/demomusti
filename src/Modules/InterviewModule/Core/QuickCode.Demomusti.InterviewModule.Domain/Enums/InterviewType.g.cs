using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demomusti.InterviewModule.Domain.Enums;

public enum InterviewType{
	[Description("Phone interview")]
	Phone,
	[Description("Video interview")]
	Video,
	[Description("In-person interview")]
	InPerson
}
