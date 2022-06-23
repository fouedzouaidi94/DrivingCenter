using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace drivingCenter.Models
{
    public partial class drivingCenterContext : DbContext
    {
        public drivingCenterContext()
        {
        }

        public drivingCenterContext(DbContextOptions<drivingCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Facture> Factures { get; set; } = null!;
        public virtual DbSet<Timetable> Timetables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SINGLETON\\SQLEXPRESS01;Initial Catalog=drivingCenter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CourseUrl)
                    .HasMaxLength(255)
                    .HasColumnName("courseUrl");

                entity.Property(e => e.Label)
                    .HasMaxLength(255)
                    .HasColumnName("label");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_userssId");
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.ToTable("Facture");

                entity.Property(e => e.FactureId).HasColumnName("factureId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("desc");

                entity.Property(e => e.Mht)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("MHT");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Ttc)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("TTC");

                entity.Property(e => e.Tva)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("TVA");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_usersId");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.ToTable("timetable");

                entity.Property(e => e.TimetableId).HasColumnName("timetableId");

                entity.Property(e => e.Candidateid).HasColumnName("candidateid");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Hour)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hour");

                entity.Property(e => e.Monitorid).HasColumnName("monitorid");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.TimetableCandidates)
                    .HasForeignKey(d => d.Candidateid)
                    .HasConstraintName("FK_candidateId");

                entity.HasOne(d => d.Monitor)
                    .WithMany(p => p.TimetableMonitors)
                    .HasForeignKey(d => d.Monitorid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_monitorId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Dob)
                    .HasMaxLength(255)
                    .HasColumnName("dob");

                entity.Property(e => e.Files)
                    .HasMaxLength(255)
                    .HasColumnName("files");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

                entity.Property(e => e.DateEcheance)
                    .HasColumnType("date")
                    .HasColumnName("date_echeance");

                entity.Property(e => e.DateVisite)
                    .HasColumnType("date")
                    .HasColumnName("date_visite");

                entity.Property(e => e.Mat)
                    .HasMaxLength(255)
                    .HasColumnName("mat");

                entity.Property(e => e.Mileage).HasColumnName("mileage");

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("model");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
