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

        public List<Entidades.Dto.UsuarioDto> getUsuarios()
        {
            var listaUsuarios = from u in context.Usuarios
                                select new Entidades.Dto.UsuarioDto
                                {
                                    Id = u.Id,
                                    NombreUsuario = u.NombreUsuario,
                                    RolId = u.RolId                                   
                                };

            //var list = context.Usuarios.FirstOrDefault();

            return listaUsuarios.ToList();
        }
    }
}
