using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Dto;
using Entidades.Enums;

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
            
            if (Usuario.RolId == 2)
            {
                Usuario.ClubId = context.Delegados.Where(d => d.UsuarioId.Equals(Usuario.Id)).Select(d => d.ClubId).FirstOrDefault();
            }

            return Usuario;
        }

        public Entidades.Usuarios validarUsuario(int rolId, string txtDNI)
        {
            Usuarios usuarioBD = (from u in context.Usuarios
                                  where u.NombreUsuario == txtDNI
                                  && u.RolId == rolId
                                  select u).FirstOrDefault();
            return usuarioBD;
        }
        public Entidades.Usuarios crearUsuario(Entidades.Usuarios usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            return usuario;
            
        }
        public List<Entidades.Dto.UsuarioDto> getRoles(string nombreUsuario)
        {
            var rolesUsuario =    from u in context.Usuarios
                                  from r in context.Roles
                                  where u.NombreUsuario == nombreUsuario
                                  && u.RolId == r.Id
                                  select new Entidades.Dto.UsuarioDto
                                  {
                                      NombreUsuario = u.NombreUsuario,
                                      RolId = r.Id,
                                      NombreRol = r.Descripcion
                                  };

            return rolesUsuario.ToList();
        }
        public Entidades.Dto.UsuarioDto getCarnet(string usuario, int rolId)
        {
            switch (rolId)
            {
                case (int)RolesEnum.Entrenador:
                    var carnetEntrenador = from u in context.Usuarios
                                 from e in context.Entrenadores
                                 where e.DNI == usuario
                                 select new Entidades.Dto.UsuarioDto
                                 {
                                     Nombre = e.Nombre,
                                     Apellido = e.Apellido,
                                     FechaNac = e.FechaNac,
                                     FechaEMMAC = e.FechaEMMAC,
                                     DNI = e.DNI,
                                     Habilitado = e.Habilitado,
                                     Foto = e.Foto,
                                     NombreRol = RolesEnum.Entrenador.ToString()
                                 };

                    return carnetEntrenador.FirstOrDefault();

                    case (int)RolesEnum.Arbitro:
                    var carnetArbitro = from u in context.Usuarios
                                 from a in context.Arbitros
                                 where a.DNI == usuario
                                 select new Entidades.Dto.UsuarioDto
                                 {
                                     Nombre = a.Nombre,
                                     Apellido = a.Apellido,
                                     FechaNac = a.FechaNac,
                                     FechaEMMAC = a.FechaEMMAC,
                                     DNI = a.DNI,
                                     Habilitado = a.Habilitado,
                                     Foto = a.Foto,
                                     NombreRol = RolesEnum.Arbitro.ToString()
                                 };

                    return carnetArbitro.FirstOrDefault();

                case (int)RolesEnum.Jugador:
                    var carnetJugador = from u in context.Usuarios
                                        from j in context.Jugadores
                                        where j.DNI == usuario
                                        select new Entidades.Dto.UsuarioDto
                                        {
                                            Nombre = j.Nombre,
                                            Apellido = j.Apellido,
                                            FechaNac = j.FechaNac,
                                            FechaEMMAC = j.FechaEMMAC,
                                            DNI = j.DNI,
                                            Habilitado = j.Habilitado,
                                            Sexo = j.Sexo,
                                            Club = j.Clubes.Nombre,
                                            Foto = j.Foto,
                                            NombreRol = RolesEnum.Jugador.ToString()
                                        };

                    return carnetJugador.FirstOrDefault();

                default:
                    return null;
            }

            
        }
    }
}
