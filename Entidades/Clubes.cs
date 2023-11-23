namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clubes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clubes()
        {
            Equipos = new HashSet<Equipos>();
            Jugadores = new HashSet<Jugadores>();
            Delegados = new HashSet<Delegados>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        public string Cuit { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Domicilio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipos> Equipos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jugadores> Jugadores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delegados> Delegados { get; set; }
    }
}
