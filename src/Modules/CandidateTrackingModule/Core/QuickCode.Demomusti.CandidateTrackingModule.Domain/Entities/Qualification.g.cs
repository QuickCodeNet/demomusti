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

[Table("QUALIFICATIONS")]
public partial class Qualification : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CANDIDATE_ID")]
	public int CandidateId { get; set; }
	
	[Column("DEGREE")]
	[StringLength(250)]
	public string Degree { get; set; }
	
	[Column("UNIVERSITY")]
	[StringLength(250)]
	public string University { get; set; }
	
	[Column("GRADUATION_DATE")]
	public DateTime GraduationDate { get; set; }
	
	[ForeignKey("CandidateId")]
	[InverseProperty(nameof(Candidate.Qualifications))]
	public virtual Candidate Candidate { get; set; } = null!;

}

