using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.CandidateTrackingModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;

[Table("CANDIDATES")]
public partial class Candidate : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("FIRST_NAME")]
	[StringLength(250)]
	public string FirstName { get; set; }
	
	[Column("LAST_NAME")]
	[StringLength(250)]
	public string LastName { get; set; }
	
	[Column("EMAIL")]
	[StringLength(500)]
	public string Email { get; set; }
	
	[Column("PHONE_NUMBER")]
	[StringLength(50)]
	public string PhoneNumber { get; set; }
	
	[Column("RESUME")]
	public byte[] Resume { get; set; }
	
	[Column("APPLICATION_DATE")]
	public DateTime ApplicationDate { get; set; }
	
	[Column("APPLICATION_STATUS", TypeName = "nvarchar(250)")]
	public ApplicationStatus ApplicationStatus { get; set; }
	
	[Column("AVATAR")]
	[StringLength(500)]
	public string Avatar { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Qualification.Candidate))]
	public virtual ICollection<Qualification> Qualifications { get; } = new List<Qualification>();


	[InverseProperty(nameof(Skill.Candidate))]
	public virtual ICollection<Skill> Skills { get; } = new List<Skill>();


	[InverseProperty(nameof(Experience.Candidate))]
	public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();


	[InverseProperty(nameof(ApplicationNote.Candidate))]
	public virtual ICollection<ApplicationNote> ApplicationNotes { get; } = new List<ApplicationNote>();


	[InverseProperty(nameof(CandidateSource.Candidate))]
	public virtual ICollection<CandidateSource> CandidateSources { get; } = new List<CandidateSource>();

}

