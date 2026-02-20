using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.Demomusti.InterviewModule.Domain.Entities;
using QuickCode.Demomusti.InterviewModule.Domain.Enums;

namespace QuickCode.Demomusti.InterviewModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Interview> Interview { get; set; }

	public virtual DbSet<Interviewer> Interviewer { get; set; }

	public virtual DbSet<InterviewFeedbackQuestion> InterviewFeedbackQuestion { get; set; }

	public virtual DbSet<InterviewFeedbackAnswer> InterviewFeedbackAnswer { get; set; }

	public virtual DbSet<InterviewSchedule> InterviewSchedule { get; set; }

	public virtual DbSet<InterviewNote> InterviewNote { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Interview>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterInterviewInterviewType = new ValueConverter<InterviewType, string>(
		v => v.ToString(),
		v => (InterviewType)Enum.Parse(typeof(InterviewType), v));

		modelBuilder.Entity<Interview>()
		.Property(b => b.InterviewType)
		.HasConversion(converterInterviewInterviewType);


		var converterInterviewInterviewStatus = new ValueConverter<InterviewStatus, string>(
		v => v.ToString(),
		v => (InterviewStatus)Enum.Parse(typeof(InterviewStatus), v));

		modelBuilder.Entity<Interview>()
		.Property(b => b.InterviewStatus)
		.HasConversion(converterInterviewInterviewStatus);

		modelBuilder.Entity<Interviewer>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Interview>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Interview>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Interviewer>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Interviewer>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<InterviewFeedbackQuestion>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<InterviewFeedbackQuestion>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<InterviewFeedbackAnswer>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<InterviewFeedbackAnswer>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<InterviewSchedule>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<InterviewSchedule>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<InterviewNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<InterviewNote>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Interview>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Interviewer>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<InterviewFeedbackQuestion>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<InterviewFeedbackAnswer>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<InterviewSchedule>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<InterviewNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Interview>()
			.HasOne(e => e.Interviewer)
			.WithMany(p => p.Interviews)
			.HasForeignKey(e => e.InterviewerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<InterviewFeedbackAnswer>()
			.HasOne(e => e.Interview)
			.WithMany(p => p.InterviewFeedbackAnswers)
			.HasForeignKey(e => e.InterviewId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<InterviewFeedbackAnswer>()
			.HasOne(e => e.InterviewFeedbackQuestion)
			.WithMany(p => p.InterviewFeedbackAnswers)
			.HasForeignKey(e => e.QuestionId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<InterviewSchedule>()
			.HasOne(e => e.Interview)
			.WithMany(p => p.InterviewSchedules)
			.HasForeignKey(e => e.InterviewId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<InterviewNote>()
			.HasOne(e => e.Interview)
			.WithMany(p => p.InterviewNotes)
			.HasForeignKey(e => e.InterviewId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
