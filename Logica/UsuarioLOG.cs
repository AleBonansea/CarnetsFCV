using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    public class UsuarioLOG
    {
        Datos.UsuarioDA usuario = new Datos.UsuarioDA();

        public Entidades.Dto.UsuarioDto getUsuarios(string contr, string nombreUs)
        {
            return usuario.getUsuarios(contr, nombreUs);
        }
    }
}
