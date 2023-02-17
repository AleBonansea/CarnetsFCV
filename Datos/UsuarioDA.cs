using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Dto;

namespace Datos
{
    public class UsuarioDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.UsuarioDto> getUsuarios(string contr, string nombreUs)
        {
            var listaUsuarios = from u in context.Usuarios
                                where u.NombreUsuario == nombreUs
                                && u.Contraseña == contr
                                select new Entidades.Dto.UsuarioDto
                                {
                                    Id = u.Id,
                                    NombreUsuario = u.NombreUsuario,
                                    Contraseña = u.Contraseña,
                                    RolId = u.RolId                                   
                                };

            return listaUsuarios.ToList();
        }
    }
}
