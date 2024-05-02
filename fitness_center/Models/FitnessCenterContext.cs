using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public partial class FitnessCenterContext : DbContext
{
    public FitnessCenterContext()
    {
    }

    public FitnessCenterContext(DbContextOptions<FitnessCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<CoachForTraining> CoachForTrainings { get; set; }

    public virtual DbSet<SignTo> SignTos { get; set; }

    public virtual DbSet<TimeTraining> TimeTrainings { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<TypeMember> TypeMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\THE USER\\DESKTOP\\לימודים ו\\FITNESSCENTER\\DATA\\DATAFITNESS_CENTER.MDF;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client__3214EC07258A7165");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birthDate");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.Fhone)
                .HasMaxLength(20)
                .HasColumnName("fhone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .HasColumnName("lastName");
            entity.Property(e => e.TypeMemberCode).HasColumnName("typeMemberCode");

            entity.HasOne(d => d.TypeMemberCodeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.TypeMemberCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_client_ToTable");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07426F9A89");

            entity.ToTable("coach");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength();
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fhone)
                .HasMaxLength(10)
                .HasColumnName("fhone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .HasColumnName("lastName");
            entity.Property(e => e.SalaryForHower)
                .HasColumnType("money")
                .HasColumnName("salaryForHower");
        });

        modelBuilder.Entity<CoachForTraining>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0789A570A6");

            entity.ToTable("CoachForTraining");

            entity.Property(e => e.CodeCoach)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("codeCoach");
            entity.Property(e => e.CodeTraining).HasColumnName("codeTraining");

            entity.HasOne(d => d.CodeCoachNavigation).WithMany(p => p.CoachForTrainings)
                .HasForeignKey(d => d.CodeCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoachForTraining_ToTable");

            entity.HasOne(d => d.CodeTrainingNavigation).WithMany(p => p.CoachForTrainings)
                .HasForeignKey(d => d.CodeTraining)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoachForTraining_ToTable_1");
        });

        modelBuilder.Entity<SignTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__signTo__3214EC07A474F7EB");

            entity.ToTable("signTo");

            entity.Property(e => e.CodeDate).HasColumnName("codeDate");
            entity.Property(e => e.IdClient)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idClient");

            entity.HasOne(d => d.CodeDateNavigation).WithMany(p => p.SignTos)
                .HasForeignKey(d => d.CodeDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_signTo_ToTable_2");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.SignTos)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_signTo_ToTable");
        });

        modelBuilder.Entity<TimeTraining>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__timeTrai__3214EC07124AC552");

            entity.ToTable("timeTraining");

            entity.Property(e => e.CoachForTrainingCode).HasColumnName("coachForTrainingCode");
            entity.Property(e => e.Day)
                .HasMaxLength(20)
                .HasColumnName("day");
            entity.Property(e => e.NumberRoom).HasColumnName("numberRoom");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.CoachForTrainingCodeNavigation).WithMany(p => p.TimeTrainings)
                .HasForeignKey(d => d.CoachForTrainingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_timeTraining_ToTable");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__training__3214EC0782CFE0D6");

            entity.ToTable("trainings");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.PurposeOfTraining)
                .HasMaxLength(300)
                .HasColumnName("purposeOfTraining");
        });

        modelBuilder.Entity<TypeMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071276E532");

            entity.ToTable("typeMember");

            entity.Property(e => e.MonthlyPayment).HasColumnName("monthlyPayment");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
