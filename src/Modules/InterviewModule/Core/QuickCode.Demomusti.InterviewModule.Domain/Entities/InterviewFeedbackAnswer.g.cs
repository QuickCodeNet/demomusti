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

[Table("INTERVIEW_FEEDBACK_ANSWERS")]
public partial class InterviewFeedbackAnswer : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("INTERVIEW_ID")]
	public int InterviewId { get; set; }
	
	[Column("QUESTION_ID")]
	public int QuestionId { get; set; }
	
	[Column("ANSWER_TEXT")]
	[StringLength(250)]
	public string AnswerText { get; set; }
	
	[Column("ANSWER_RATING")]
	public short AnswerRating { get; set; }
	
	[ForeignKey("InterviewId")]
	[InverseProperty(nameof(Interview.InterviewFeedbackAnswers))]
	public virtual Interview Interview { get; set; } = null!;


	[ForeignKey("QuestionId")]
	[InverseProperty(nameof(InterviewFeedbackQuestion.InterviewFeedbackAnswers))]
	public virtual InterviewFeedbackQuestion InterviewFeedbackQuestion { get; set; } = null!;

}

