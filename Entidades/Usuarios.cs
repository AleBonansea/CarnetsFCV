namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            Arbitros = new HashSet<Arbitros>();
            Delegados = new HashSet<Delegados>();
            Entrenadores = new HashSet<Entrenadores>();
            Jugadores = new HashSet<Jugadores>();
        }

        public int Id { get; set; }

        public int RolId { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(30)]
        public string Contraseña { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arbitros> Arbitros { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delegados> Delegados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrenadores> Entrenadores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jugadores> Jugadores { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
