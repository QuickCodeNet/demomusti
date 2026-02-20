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

[Table("INTERVIEW_FEEDBACK_QUESTIONS")]
public partial class InterviewFeedbackQuestion : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("QUESTION_TEXT")]
	[StringLength(250)]
	public string QuestionText { get; set; }
	
	[Column("QUESTION_TYPE")]
	[StringLength(250)]
	public string QuestionType { get; set; }
	
	[InverseProperty(nameof(InterviewFeedbackAnswer.InterviewFeedbackQuestion))]
	public virtual ICollection<InterviewFeedbackAnswer> InterviewFeedbackAnswers { get; } = new List<InterviewFeedbackAnswer>();

}

