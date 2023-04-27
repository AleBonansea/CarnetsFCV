namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipos()
        {
            Jugadores = new HashSet<Jugadores>();
        }

        public int Id { get; set; }

        public int ClubId { get; set; }

        public int DivisionId { get; set; }

        public int RamaId { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }

        public virtual Clubes Clubes { get; set; }

        public virtual Divisiones Divisiones { get; set; }

        public virtual Ramas Ramas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jugadores> Jugadores { get; set; }
    }
}
