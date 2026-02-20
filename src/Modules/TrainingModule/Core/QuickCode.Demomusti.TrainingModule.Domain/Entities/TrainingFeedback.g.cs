using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.TrainingModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;

namespace QuickCode.Demomusti.TrainingModule.Domain.Entities;

[Table("TRAINING_FEEDBACKS")]
public partial class TrainingFeedback : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("EMPLOYEE_TRAINING_ID")]
	public int EmployeeTrainingId { get; set; }
	
	[Column("FEEDBACK_TEXT")]
	[StringLength(1000)]
	public string FeedbackText { get; set; }
	
	[Column("RATING")]
	public short Rating { get; set; }
	
	[Column("FEEDBACK_DATE")]
	public DateTime FeedbackDate { get; set; }
	
	[ForeignKey("EmployeeTrainingId")]
	[InverseProperty(nameof(EmployeeTraining.TrainingFeedbacks))]
	public virtual EmployeeTraining EmployeeTraining { get; set; } = null!;

}

