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

[Table("SKILLS")]
public partial class Skill : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CANDIDATE_ID")]
	public int CandidateId { get; set; }
	
	[Column("SKILL_NAME")]
	[StringLength(250)]
	public string SkillName { get; set; }
	
	[Column("PROFICIENCY")]
	[StringLength(250)]
	public string Proficiency { get; set; }
	
	[ForeignKey("CandidateId")]
	[InverseProperty(nameof(Candidate.Skills))]
	public virtual Candidate Candidate { get; set; } = null!;

}

