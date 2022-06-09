using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba_tecnica_01.Models
{
    public partial class Colegio_prueba_tecnicaContext : DbContext
    {
        public Colegio_prueba_tecnicaContext()
        {
        }

        public Colegio_prueba_tecnicaContext(DbContextOptions<Colegio_prueba_tecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<AlumnosNotasView> AlumnosNotasViews { get; set; } = null!;
        public virtual DbSet<Maestro> Maestros { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<MateriasxAlumno> MateriasxAlumnos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JVTJSPM; Database=Colegio_prueba_tecnica; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("ALUMNOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AlumnosNotasView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("alumnos_notas_view");

                entity.Property(e => e.Calificacion1).HasColumnName("calificacion_1");

                entity.Property(e => e.Calificacion2).HasColumnName("calificacion_2");

                entity.Property(e => e.Calificacion3).HasColumnName("calificacion_3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.ToTable("MAESTRO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("MATERIAS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre_materia");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_MATERIAS_MAESTRO");
            });

            modelBuilder.Entity<MateriasxAlumno>(entity =>
            {
                entity.ToTable("MATERIASxALUMNOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion1).HasColumnName("calificacion_1");

                entity.Property(e => e.Calificacion2).HasColumnName("calificacion_2");

                entity.Property(e => e.Calificacion3).HasColumnName("calificacion_3");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.MateriasxAlumnos)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK_MATERIASxALUMNOS_ALUMNOS");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MateriasxAlumnos)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("FK_MATERIASxALUMNOS_MATERIAS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
