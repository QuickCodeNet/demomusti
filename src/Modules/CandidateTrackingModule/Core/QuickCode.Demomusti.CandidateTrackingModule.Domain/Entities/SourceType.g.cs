using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.CandidateTrackingModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;

namespace QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;

[Table("SOURCE_TYPES")]
public partial class SourceType : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SOURCE_NAME")]
	[StringLength(250)]
	public string SourceName { get; set; }
	
	[InverseProperty(nameof(CandidateSource.SourceType))]
	public virtual ICollection<CandidateSource> CandidateSources { get; } = new List<CandidateSource>();

}

