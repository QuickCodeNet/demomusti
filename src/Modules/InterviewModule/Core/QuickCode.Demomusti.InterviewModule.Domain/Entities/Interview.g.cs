using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.InterviewModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Domain.Entities;

[Table("INTERVIEWS")]
public partial class Interview : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CANDIDATE_ID")]
	public int CandidateId { get; set; }
	
	[Column("INTERVIEWER_ID")]
	public int InterviewerId { get; set; }
	
	[Column("INTERVIEW_DATE")]
	public DateTime InterviewDate { get; set; }
	
	[Column("INTERVIEW_TYPE", TypeName = "nvarchar(250)")]
	public InterviewType InterviewType { get; set; }
	
	[Column("INTERVIEW_STATUS", TypeName = "nvarchar(250)")]
	public InterviewStatus InterviewStatus { get; set; }
	
	[Column("FEEDBACK")]
	[StringLength(1000)]
	public string Feedback { get; set; }
	
	[Column("RATING")]
	public short Rating { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(InterviewFeedbackAnswer.Interview))]
	public virtual ICollection<InterviewFeedbackAnswer> InterviewFeedbackAnswers { get; } = new List<InterviewFeedbackAnswer>();


	[InverseProperty(nameof(InterviewSchedule.Interview))]
	public virtual ICollection<InterviewSchedule> InterviewSchedules { get; } = new List<InterviewSchedule>();


	[InverseProperty(nameof(InterviewNote.Interview))]
	public virtual ICollection<InterviewNote> InterviewNotes { get; } = new List<InterviewNote>();


	[ForeignKey("InterviewerId")]
	[InverseProperty(nameof(Interviewer.Interviews))]
	public virtual Interviewer Interviewer { get; set; } = null!;

}

