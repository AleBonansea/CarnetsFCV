using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habilitaciones
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public int EntidadId { get; set; }
        public int RolId { get; set; }
        public bool Vigente { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
