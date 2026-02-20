using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.InterviewModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;

namespace QuickCode.Demomusti.InterviewModule.Domain.Entities;

[Table("INTERVIEW_SCHEDULES")]
public partial class InterviewSchedule : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("INTERVIEW_ID")]
	public int InterviewId { get; set; }
	
	[Column("SCHEDULED_TIME")]
	public DateTime ScheduledTime { get; set; }
	
	[Column("ROOM_NUMBER")]
	[StringLength(250)]
	public string RoomNumber { get; set; }
	
	[ForeignKey("InterviewId")]
	[InverseProperty(nameof(Interview.InterviewSchedules))]
	public virtual Interview Interview { get; set; } = null!;

}

