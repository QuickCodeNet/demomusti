using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Entities;
using QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Candidate> Candidate { get; set; }

	public virtual DbSet<Qualification> Qualification { get; set; }

	public virtual DbSet<Skill> Skill { get; set; }

	public virtual DbSet<Experience> Experience { get; set; }

	public virtual DbSet<ApplicationNote> ApplicationNote { get; set; }

	public virtual DbSet<SourceType> SourceType { get; set; }

	public virtual DbSet<CandidateSource> CandidateSource { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Candidate>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterCandidateApplicationStatus = new ValueConverter<ApplicationStatus, string>(
		v => v.ToString(),
		v => (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), v));

		modelBuilder.Entity<Candidate>()
		.Property(b => b.ApplicationStatus)
		.HasConversion(converterCandidateApplicationStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Candidate>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Candidate>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Qualification>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Qualification>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Skill>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Skill>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Experience>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Experience>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ApplicationNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ApplicationNote>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<SourceType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<SourceType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CandidateSource>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CandidateSource>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Candidate>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Qualification>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Skill>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Experience>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ApplicationNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<SourceType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CandidateSource>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Qualification>()
			.HasOne(e => e.Candidate)
			.WithMany(p => p.Qualifications)
			.HasForeignKey(e => e.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Skill>()
			.HasOne(e => e.Candidate)
			.WithMany(p => p.Skills)
			.HasForeignKey(e => e.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Experience>()
			.HasOne(e => e.Candidate)
			.WithMany(p => p.Experiences)
			.HasForeignKey(e => e.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ApplicationNote>()
			.HasOne(e => e.Candidate)
			.WithMany(p => p.ApplicationNotes)
			.HasForeignKey(e => e.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CandidateSource>()
			.HasOne(e => e.Candidate)
			.WithMany(p => p.CandidateSources)
			.HasForeignKey(e => e.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CandidateSource>()
			.HasOne(e => e.SourceType)
			.WithMany(p => p.CandidateSources)
			.HasForeignKey(e => e.SourceTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
