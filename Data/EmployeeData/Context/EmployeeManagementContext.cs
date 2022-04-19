using System;
using Data.EmployeeData.Entities;
using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.EmployeeData.Context
{
    public partial class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeHobby> EmployeeHobbies { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Hobby> Hobbies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<ExceptionLogger> ExceptionLogger { get; set; }

        public virtual DbSet<EmployeeListWithPageSort> EmployeeListWithPageSort { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id);

                entity.Property(e => e.About).HasMaxLength(5000);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeHobby>(entity =>
            {
                entity.Property(e => e.Id);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.EmployeeHobbies)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeHobbies_Employee");

                entity.HasOne(d => d.IdHobbyNavigation)
                    .WithMany(p => p.EmployeeHobbies)
                    .HasForeignKey(d => d.IdHobby)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeHobbies_Hobbies");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSkills_Employee");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.IdSkill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSkills_EmployeeSkills");
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.Property(e => e.Hobby1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Hobby");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Role1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Skill1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Skill");
            });

            modelBuilder.Entity<ExceptionLogger>(entity =>
            {
                entity.ToTable("ExceptionLogger");
                entity.Property(e => e.Id);
                entity.Property(e => e.LogTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeListWithPageSort>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
