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

[Table("TRAINING_CATEGORIES")]
public partial class TrainingCategory : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CATEGORY_NAME")]
	[StringLength(250)]
	public string CategoryName { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[InverseProperty(nameof(TrainingCategoryAssignment.TrainingCategory))]
	public virtual ICollection<TrainingCategoryAssignment> TrainingCategoryAssignments { get; } = new List<TrainingCategoryAssignment>();

}

