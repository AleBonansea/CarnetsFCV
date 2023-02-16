namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            Jugadores = new HashSet<Jugador>();
        }

        public int Id { get; set; }

        public int ClubId { get; set; }

        public int DivisionId { get; set; }

        public int RamaId { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }

        public virtual Clube Clube { get; set; }

        public virtual Division Divisione { get; set; }

        public virtual Rama Rama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}
