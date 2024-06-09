using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public partial class BlogsSiteContext : DbContext
{
    public BlogsSiteContext()
    {
    }

    public BlogsSiteContext(DbContextOptions<BlogsSiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<CoachForTraining> CoachForTrainings { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<SignTo> SignTos { get; set; }

    public virtual DbSet<TimeTraining> TimeTrainings { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<TypeMember> TypeMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\The user\\Desktop\\לימודים ו\\FitnessCenter\\data\\dataFitness_center.mdf\";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07E6B92D03");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birthDate");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Fhone)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("fhone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
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
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Fhone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("fhone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
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
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
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

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07FC270F55");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idClient");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_ToTable");
        });

        modelBuilder.Entity<SignTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__signTo__3214EC07A474F7EB");

            entity.ToTable("signTo");

            entity.Property(e => e.CodeDate).HasColumnName("codeDate");
            entity.Property(e => e.IdClient)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
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
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
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
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.PurposeOfTraining)
                .HasMaxLength(300)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("purposeOfTraining");
        });

        modelBuilder.Entity<TypeMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071276E532");

            entity.ToTable("typeMember");

            entity.Property(e => e.CountTraining).HasColumnName("countTraining");
            entity.Property(e => e.MonthlyPayment).HasColumnName("monthlyPayment");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
