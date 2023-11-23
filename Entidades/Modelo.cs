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

        public virtual DbSet<Arbitros> Arbitros { get; set; }
        public virtual DbSet<Clubes> Clubes { get; set; }
        public virtual DbSet<Delegados> Delegados { get; set; }
        public virtual DbSet<Divisiones> Divisiones { get; set; }
        public virtual DbSet<Entrenadores> Entrenadores { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<Ramas> Ramas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arbitros>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitros>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitros>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Arbitros>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clubes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clubes>()
                .Property(e => e.Cuit)
                .IsUnicode(false);

            modelBuilder.Entity<Clubes>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Clubes>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Clubes)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubes>()
                .HasMany(e => e.Jugadores)
                .WithRequired(e => e.Clubes)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubes>()
                .HasMany(e => e.Delegados)
                .WithRequired(e => e.Clubes)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delegados>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Delegados>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Delegados>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Divisiones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Divisiones>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Divisiones)
                .HasForeignKey(e => e.DivisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entrenadores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenadores>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenadores>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Entrenadores>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Equipos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Equipos>()
                .HasMany(e => e.Jugadores)
                .WithRequired(e => e.Equipos)
                .HasForeignKey(e => e.EquipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jugadores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Jugadores>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Jugadores>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Jugadores>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Jugadores>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ramas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ramas>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Ramas)
                .HasForeignKey(e => e.RamaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RolId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Arbitros)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Delegados)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Entrenadores)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Jugadores)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);
        }
    }
}
