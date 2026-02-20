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

[Table("INTERVIEW_NOTES")]
public partial class InterviewNote : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("INTERVIEW_ID")]
	public int InterviewId { get; set; }
	
	[Column("NOTE_TEXT")]
	[StringLength(1000)]
	public string NoteText { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("InterviewId")]
	[InverseProperty(nameof(Interview.InterviewNotes))]
	public virtual Interview Interview { get; set; } = null!;

}

