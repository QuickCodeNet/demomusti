using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.Demomusti.TrainingModule.Domain.Entities;
using QuickCode.Demomusti.TrainingModule.Domain.Enums;

namespace QuickCode.Demomusti.TrainingModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Training> Training { get; set; }

	public virtual DbSet<EmployeeTraining> EmployeeTraining { get; set; }

	public virtual DbSet<TrainingMaterial> TrainingMaterial { get; set; }

	public virtual DbSet<TrainingFeedback> TrainingFeedback { get; set; }

	public virtual DbSet<TrainingSession> TrainingSession { get; set; }

	public virtual DbSet<TrainingCategory> TrainingCategory { get; set; }

	public virtual DbSet<TrainingCategoryAssignment> TrainingCategoryAssignment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Training>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterTrainingTrainingType = new ValueConverter<TrainingType, string>(
		v => v.ToString(),
		v => (TrainingType)Enum.Parse(typeof(TrainingType), v));

		modelBuilder.Entity<Training>()
		.Property(b => b.TrainingType)
		.HasConversion(converterTrainingTrainingType);


		var converterTrainingStatus = new ValueConverter<TrainingStatus, string>(
		v => v.ToString(),
		v => (TrainingStatus)Enum.Parse(typeof(TrainingStatus), v));

		modelBuilder.Entity<Training>()
		.Property(b => b.Status)
		.HasConversion(converterTrainingStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Training>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Training>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<EmployeeTraining>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<EmployeeTraining>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TrainingMaterial>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TrainingMaterial>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TrainingFeedback>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TrainingFeedback>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TrainingSession>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TrainingSession>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TrainingCategory>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TrainingCategory>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TrainingCategoryAssignment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TrainingCategoryAssignment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Training>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<EmployeeTraining>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TrainingMaterial>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TrainingFeedback>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TrainingSession>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TrainingCategory>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TrainingCategoryAssignment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<EmployeeTraining>()
			.HasOne(e => e.Training)
			.WithMany(p => p.EmployeeTrainings)
			.HasForeignKey(e => e.TrainingId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TrainingMaterial>()
			.HasOne(e => e.Training)
			.WithMany(p => p.TrainingMaterials)
			.HasForeignKey(e => e.TrainingId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TrainingFeedback>()
			.HasOne(e => e.EmployeeTraining)
			.WithMany(p => p.TrainingFeedbacks)
			.HasForeignKey(e => e.EmployeeTrainingId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TrainingSession>()
			.HasOne(e => e.Training)
			.WithMany(p => p.TrainingSessions)
			.HasForeignKey(e => e.TrainingId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TrainingCategoryAssignment>()
			.HasOne(e => e.Training)
			.WithMany(p => p.TrainingCategoryAssignments)
			.HasForeignKey(e => e.TrainingId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TrainingCategoryAssignment>()
			.HasOne(e => e.TrainingCategory)
			.WithMany(p => p.TrainingCategoryAssignments)
			.HasForeignKey(e => e.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
