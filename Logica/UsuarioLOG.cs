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

        public Entidades.Usuarios validarUsuario(int rolId, string txtDNI)
        {
            return usuario.validarUsuario(rolId, txtDNI);
        }
        public Entidades.Usuarios crearUsuarioEntrenador(Entidades.Usuarios usuarioEntrenador)
        {
            return usuario.crearUsuarioEntrenador(usuarioEntrenador);
        }

    }
}
