using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Delegado { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
