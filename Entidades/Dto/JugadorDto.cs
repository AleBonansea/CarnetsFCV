using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class JugadorDto
    {
        public int Id { get; set; }
        public string Club { get; set; }
        public string Equipo { get; set; }
        public string División { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaEMMAC { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Sexo { get; set; }
        public bool Habilitado { get; set; }
    }
}
