using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demomusti.InterviewModule.Domain;
using QuickCode.Demomusti.Common;
using QuickCode.Demomusti.Common.Auditing;

namespace QuickCode.Demomusti.InterviewModule.Domain.Entities;

[Table("INTERVIEWERS")]
public partial class Interviewer : BaseSoftDeletable, IAuditableEntity 
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
	
	[Column("DEPARTMENT")]
	[StringLength(250)]
	public string Department { get; set; }
	
	[Column("AVATAR")]
	[StringLength(500)]
	public string Avatar { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Interview.Interviewer))]
	public virtual ICollection<Interview> Interviews { get; } = new List<Interview>();

}

