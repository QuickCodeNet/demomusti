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

[Table("TRAINING_SESSIONS")]
public partial class TrainingSession : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("TRAINING_ID")]
	public int TrainingId { get; set; }
	
	[Column("SESSION_NAME")]
	[StringLength(250)]
	public string SessionName { get; set; }
	
	[Column("SESSION_DATE")]
	public DateTime SessionDate { get; set; }
	
	[Column("SESSION_LOCATION")]
	[StringLength(250)]
	public string SessionLocation { get; set; }
	
	[ForeignKey("TrainingId")]
	[InverseProperty(nameof(Training.TrainingSessions))]
	public virtual Training Training { get; set; } = null!;

}

