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

[Table("TRAINING_CATEGORY_ASSIGNMENTS")]
public partial class TrainingCategoryAssignment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("TRAINING_ID")]
	public int TrainingId { get; set; }
	
	[Column("CATEGORY_ID")]
	public int CategoryId { get; set; }
	
	[ForeignKey("TrainingId")]
	[InverseProperty(nameof(Training.TrainingCategoryAssignments))]
	public virtual Training Training { get; set; } = null!;


	[ForeignKey("CategoryId")]
	[InverseProperty(nameof(TrainingCategory.TrainingCategoryAssignments))]
	public virtual TrainingCategory TrainingCategory { get; set; } = null!;

}

