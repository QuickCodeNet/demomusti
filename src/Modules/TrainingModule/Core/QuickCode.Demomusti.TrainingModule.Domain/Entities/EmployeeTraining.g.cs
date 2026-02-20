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

[Table("EMPLOYEE_TRAININGS")]
public partial class EmployeeTraining : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("EMPLOYEE_ID")]
	public int EmployeeId { get; set; }
	
	[Column("TRAINING_ID")]
	public int TrainingId { get; set; }
	
	[Column("ENROLLMENT_DATE")]
	public DateTime EnrollmentDate { get; set; }
	
	[Column("COMPLETION_DATE")]
	public DateTime CompletionDate { get; set; }
	
	[Column("GRADE")]
	[StringLength(250)]
	public string Grade { get; set; }
	
	[InverseProperty(nameof(TrainingFeedback.EmployeeTraining))]
	public virtual ICollection<TrainingFeedback> TrainingFeedbacks { get; } = new List<TrainingFeedback>();


	[ForeignKey("TrainingId")]
	[InverseProperty(nameof(Training.EmployeeTrainings))]
	public virtual Training Training { get; set; } = null!;

}

