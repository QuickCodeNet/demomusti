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

[Table("CANDIDATE_SOURCES")]
public partial class CandidateSource : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CANDIDATE_ID")]
	public int CandidateId { get; set; }
	
	[Column("SOURCE_TYPE_ID")]
	public int SourceTypeId { get; set; }
	
	[ForeignKey("CandidateId")]
	[InverseProperty(nameof(Candidate.CandidateSources))]
	public virtual Candidate Candidate { get; set; } = null!;


	[ForeignKey("SourceTypeId")]
	[InverseProperty(nameof(SourceType.CandidateSources))]
	public virtual SourceType SourceType { get; set; } = null!;

}

