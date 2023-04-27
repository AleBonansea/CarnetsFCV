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

        public Entidades.Dto.UsuarioDto getUsuarios(string contr, string nombreUs)
        {
            var Usuario = (from u in context.Usuarios
                                where u.NombreUsuario == nombreUs
                                && u.Contraseña == contr
                                select new Entidades.Dto.UsuarioDto
                                {
                                    Id = u.Id,
                                    NombreUsuario = u.NombreUsuario,
                                    Contraseña = u.Contraseña,
                                    RolId = u.RolId
                                }).FirstOrDefault();
            
            if (Usuario.RolId != 1)
            {
                Usuario.ClubId = context.Delegados.Where(d => d.UsuarioId.Equals(Usuario.Id)).Select(d => d.ClubId).FirstOrDefault();
            }

            return Usuario;
        }
    }
}
