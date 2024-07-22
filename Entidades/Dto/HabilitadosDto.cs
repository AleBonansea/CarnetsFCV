using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class HabilitadosDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool Vigente { get; set; }
        public int SexoId { get; set; }
    }
}
