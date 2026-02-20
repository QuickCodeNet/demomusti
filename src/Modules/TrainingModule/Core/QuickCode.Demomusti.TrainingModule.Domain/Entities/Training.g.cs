using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.TrainingModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Domain.Entities;

[Table("TRAINING")]
public partial class Training : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("COURSE_NAME")]
	[StringLength(250)]
	public string CourseName { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("TRAINING_TYPE", TypeName = "nvarchar(250)")]
	public TrainingType TrainingType { get; set; }
	
	[Column("START_DATE")]
	public DateTime StartDate { get; set; }
	
	[Column("END_DATE")]
	public DateTime EndDate { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public TrainingStatus Status { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(EmployeeTraining.Training))]
	public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; } = new List<EmployeeTraining>();


	[InverseProperty(nameof(TrainingMaterial.Training))]
	public virtual ICollection<TrainingMaterial> TrainingMaterials { get; } = new List<TrainingMaterial>();


	[InverseProperty(nameof(TrainingSession.Training))]
	public virtual ICollection<TrainingSession> TrainingSessions { get; } = new List<TrainingSession>();


	[InverseProperty(nameof(TrainingCategoryAssignment.Training))]
	public virtual ICollection<TrainingCategoryAssignment> TrainingCategoryAssignments { get; } = new List<TrainingCategoryAssignment>();

}

