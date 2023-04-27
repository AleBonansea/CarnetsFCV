using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class EquipoDto
    {
        public int Id { get; set; }
        public string NombreClub { get; set; }
        public string NombreEquipo { get; set; }
        public string Division { get; set; }
        public string Rama { get; set; }
    }
}
