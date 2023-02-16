using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Entidades
{
    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Arbitro> Arbitros { get; set; }
        public virtual DbSet<Clube> Clubes { get; set; }
        public virtual DbSet<Delegado> Delegados { get; set; }
        public virtual DbSet<Division> Divisiones { get; set; }
        public virtual DbSet<Entrenador> Entrenadores { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Jugador> Jugadores { get; set; }
        public virtual DbSet<Rama> Ramas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arbitro>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitro>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitro>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitro>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clube>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clube>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Clube>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Clube)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clube>()
                .HasMany(e => e.Delegados)
                .WithRequired(e => e.Clube)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delegado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Delegado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Delegado>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Division>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Division>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Divisione)
                .HasForeignKey(e => e.DivisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entrenador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenador>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenador>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenador>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Jugadores)
                .WithRequired(e => e.Equipos)
                .HasForeignKey(e => e.EquipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jugador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Jugador>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Jugador>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Jugador>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Jugador>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rama>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Rama>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Rama)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Arbitros)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Delegados)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Entrenadores)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Jugadores)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
