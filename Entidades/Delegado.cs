namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delegados")]
    public partial class Delegado
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int ClubId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int Telefono { get; set; }

        public virtual Clube Clube { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
