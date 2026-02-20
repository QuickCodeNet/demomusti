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

[Table("EXPERIENCES")]
public partial class Experience : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CANDIDATE_ID")]
	public int CandidateId { get; set; }
	
	[Column("COMPANY_NAME")]
	[StringLength(250)]
	public string CompanyName { get; set; }
	
	[Column("JOB_TITLE")]
	[StringLength(250)]
	public string JobTitle { get; set; }
	
	[Column("START_DATE")]
	public DateTime StartDate { get; set; }
	
	[Column("END_DATE")]
	public DateTime EndDate { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[ForeignKey("CandidateId")]
	[InverseProperty(nameof(Candidate.Experiences))]
	public virtual Candidate Candidate { get; set; } = null!;

}

