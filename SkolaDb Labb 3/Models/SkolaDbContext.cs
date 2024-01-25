using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkolaDb_Labb_3.Models;

public partial class SkolaDbContext : DbContext
{
    public SkolaDbContext()
    {
    }

    public SkolaDbContext(DbContextOptions<SkolaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBetyg> TblBetygs { get; set; }

    public virtual DbSet<TblKur> TblKurs { get; set; }

    public virtual DbSet<TblPersonal> TblPersonals { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblStudentKursBetyg> TblStudentKursBetygs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = BLACKBOX; Initial Catalog = SkolaDB; TrustServerCertificate=True; Integrated security = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBetyg>(entity =>
        {
            entity.HasKey(e => e.BetygId);

            entity.ToTable("tblBetyg");

            entity.Property(e => e.BetygId).HasColumnName("BetygID");
            entity.Property(e => e.Betyg)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

            entity.HasOne(d => d.Personal).WithMany(p => p.TblBetygs)
                .HasForeignKey(d => d.PersonalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBetyg_tblPersonal");
        });

        modelBuilder.Entity<TblKur>(entity =>
        {
            entity.HasKey(e => e.KursId);

            entity.ToTable("tblKurs");

            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.KursNamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

            entity.HasOne(d => d.Personal).WithMany(p => p.TblKurs)
                .HasForeignKey(d => d.PersonalId)
                .HasConstraintName("FK_tblKurs_tblPersonal");
        });

        modelBuilder.Entity<TblPersonal>(entity =>
        {
            entity.HasKey(e => e.PersonalId);

            entity.ToTable("tblPersonal");

            entity.Property(e => e.PersonalId).HasColumnName("PersonalID");
            entity.Property(e => e.Befattning)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Klass)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudentKursBetyg>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblStudentKursBetyg");

            entity.Property(e => e.BetygId).HasColumnName("BetygID");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Betyg).WithMany()
                .HasForeignKey(d => d.BetygId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBetygSättning_tblBetyg");

            entity.HasOne(d => d.Kurs).WithMany()
                .HasForeignKey(d => d.KursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBetygSättning_tblKurs");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBetygSättning_tblStudent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
