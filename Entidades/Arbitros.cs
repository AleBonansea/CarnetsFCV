namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Arbitros
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime FechaEMMAC { get; set; }

        [Required]
        [StringLength(15)]
        public string DNI { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int Telefono { get; set; }

        [Required]
        public byte[] Foto { get; set; }

        public bool Habilitado { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
