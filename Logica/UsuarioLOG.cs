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
        public Entidades.Usuarios crearUsuario(Entidades.Usuarios usuarioEntrenador)
        {
            return usuario.crearUsuario(usuarioEntrenador);
        }
        public List<Entidades.Dto.UsuarioDto> getRoles(string nombreUsuario)
        {
            return usuario.getRoles(nombreUsuario);
        }
        public Entidades.Dto.UsuarioDto getCarnet(string nombreUsuario, int rolId)
        {
            return usuario.getCarnet(nombreUsuario, rolId);
        }
        public Entidades.Usuarios getUsuarioById(int usuarioId)
        {
            return usuario.getUsuarioById(usuarioId);
        }
        public Entidades.Usuarios modificarContraseña(Entidades.Usuarios usuarioAModificar)
        {
            return usuario.modificarContraseña(usuarioAModificar);
        }
        public Entidades.Dto.UsuarioDto getUsuarioByNombre(string nombreUsuario)
        {
            return usuario.getUsuarioByNombre(nombreUsuario);
        }

    }
}
