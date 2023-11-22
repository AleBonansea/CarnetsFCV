using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
        public int? ClubId { get; set; }
        public string NombreRol { get; set; }
        public string Club { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaEMMAC { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
        public bool Habilitado { get; set; }
        public byte[] Foto { get; set; }
    }
}
