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

[Table("TRAINING_MATERIALS")]
public partial class TrainingMaterial : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("TRAINING_ID")]
	public int TrainingId { get; set; }
	
	[Column("MATERIAL_NAME")]
	[StringLength(250)]
	public string MaterialName { get; set; }
	
	[Column("MATERIAL_URL")]
	[StringLength(1000)]
	public string MaterialUrl { get; set; }
	
	[Column("MATERIAL_FILE")]
	public byte[] MaterialFile { get; set; }
	
	[ForeignKey("TrainingId")]
	[InverseProperty(nameof(Training.TrainingMaterials))]
	public virtual Training Training { get; set; } = null!;

}

