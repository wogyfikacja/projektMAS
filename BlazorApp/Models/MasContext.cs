using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models;
/// <summary>
/// A context for the db. It was generated using DB first approach
/// </summary>
public partial class MasContext : DbContext
{
    public MasContext()
    {
    }

    public MasContext(DbContextOptions<MasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Dayofwork> Dayofworks { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Medicalequipment> Medicalequipments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Tool> Tools { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres; Password=elmino109");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => new { e.PersonPesel, e.ServiceIdService, e.Start, e.End }).HasName("appointment_pk");

            entity.ToTable("appointment");

            entity.Property(e => e.PersonPesel)
                .HasMaxLength(11)
                .HasColumnName("person_pesel");
            entity.Property(e => e.ServiceIdService).HasColumnName("service_id_service");
            entity.Property(e => e.Start)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_appointment");
            entity.Property(e => e.End)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_appointment");
            entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");

            entity.HasOne(d => d.PersonPeselNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PersonPesel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_person");

            entity.HasOne(d => d.ServiceIdServiceNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceIdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_service");
        });

        modelBuilder.Entity<Dayofwork>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.Pesel }).HasName("dayofwork_pk");

            entity.ToTable("dayofwork");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .HasColumnName("pesel");
            entity.Property(e => e.End).HasColumnName("end");
            entity.Property(e => e.Start).HasColumnName("start");

            entity.HasOne(d => d.PeselNavigation).WithMany(p => p.Dayofworks)
                .HasForeignKey(d => d.Pesel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dayofwork_person");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MedicalequipmentId).HasName("machine_pk");

            entity.ToTable("machine");

            entity.Property(e => e.MedicalequipmentId)
                .ValueGeneratedNever()
                .HasColumnName("medicalequipment_id");
            entity.Property(e => e.LicenseIsNeeded).HasColumnName("license_is_needed");

            entity.HasOne(d => d.Medicalequipment).WithOne(p => p.Machine)
                .HasForeignKey<Machine>(d => d.MedicalequipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("table_6_medicalequipment");
        });

        modelBuilder.Entity<Medicalequipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicalequipment_pk");

            entity.ToTable("medicalequipment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Depth).HasColumnName("depth");
            entity.Property(e => e.Descript).HasColumnName("descript");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Room).HasColumnName("room");
            entity.Property(e => e.Width).HasColumnName("width");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Pesel).HasName("person_pk");

            entity.ToTable("person");

            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .HasColumnName("pesel");
            entity.Property(e => e.DoctorSpec)
                .HasMaxLength(15)
                .HasColumnName("doctor_spec");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.NurseSpec)
                .HasMaxLength(15)
                .HasColumnName("nurse_spec");
            entity.Property(e => e.Patient).HasColumnName("patient");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname");
            entity.Property(e => e.Worker).HasColumnName("worker");

            entity.HasMany(d => d.ServiceIdServices).WithMany(p => p.PersonPesels)
                .UsingEntity<Dictionary<string, object>>(
                    "Nurseinservice",
                    r => r.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceIdService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("nurseinservice_service"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonPesel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("nurseinservice_person"),
                    j =>
                    {
                        j.HasKey("PersonPesel", "ServiceIdService").HasName("nurseinservice_pk");
                        j.ToTable("nurseinservice");
                        j.IndexerProperty<string>("PersonPesel")
                            .HasMaxLength(11)
                            .HasColumnName("person_pesel");
                        j.IndexerProperty<int>("ServiceIdService").HasColumnName("service_id_service");
                    });
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("service_pk");

            entity.ToTable("service");

            entity.Property(e => e.IdService)
                .ValueGeneratedNever()
                .HasColumnName("id_service");
            entity.Property(e => e.DoctorPesel)
                .HasMaxLength(11)
                .HasColumnName("doctor_pesel");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Room).HasColumnName("room");

            entity.HasOne(d => d.DoctorPeselNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.DoctorPesel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_person");

            entity.HasMany(d => d.Medicalequipments).WithMany(p => p.ServiceIdServices)
                .UsingEntity<Dictionary<string, object>>(
                    "Equipmentservice",
                    r => r.HasOne<Medicalequipment>().WithMany()
                        .HasForeignKey("MedicalequipmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("table_8_medicalequipment"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceIdService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("table_8_service"),
                    j =>
                    {
                        j.HasKey("ServiceIdService", "MedicalequipmentId").HasName("equipmentservice_pk");
                        j.ToTable("equipmentservice");
                        j.IndexerProperty<int>("ServiceIdService").HasColumnName("service_id_service");
                        j.IndexerProperty<int>("MedicalequipmentId").HasColumnName("medicalequipment_id");
                    });
        });

        modelBuilder.Entity<Tool>(entity =>
        {
            entity.HasKey(e => e.MedicalequipmentId).HasName("tool_pk");

            entity.ToTable("tool");

            entity.Property(e => e.MedicalequipmentId)
                .ValueGeneratedNever()
                .HasColumnName("medicalequipment_id");
            entity.Property(e => e.Material).HasColumnName("material");

            entity.HasOne(d => d.Medicalequipment).WithOne(p => p.Tool)
                .HasForeignKey<Tool>(d => d.MedicalequipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("table_7_medicalequipment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
