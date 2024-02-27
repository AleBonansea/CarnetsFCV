namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jugadores
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int ClubId { get; set; }

        public int EquipoId { get; set; }

        public int SexoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNac { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEMMAC { get; set; }

        [Required]
        [StringLength(15)]
        public string DNI { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public string Telefono { get; set; }

        public byte[] Foto { get; set; }

        public bool Habilitado { get; set; }

        public virtual Clubes Clubes { get; set; }

        public virtual Equipos Equipos { get; set; }

        public virtual Sexos Sexos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
