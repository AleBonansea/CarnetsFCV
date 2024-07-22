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
                               PrimerIngreso = u.PrimerIngreso,
                               RolId = u.RolId
                           }).FirstOrDefault();

            if (Usuario != null && Usuario.RolId == 2)
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
            var rolesUsuario = from u in context.Usuarios
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
                                        join j in context.Jugadores on u.Id equals j.UsuarioId
                                        join s in context.Sexos on j.SexoId equals s.Id
                                        where j.DNI == usuario
                                        select new Entidades.Dto.UsuarioDto
                                        {
                                            Nombre = j.Nombre,
                                            Apellido = j.Apellido,
                                            FechaNac = j.FechaNac,
                                            FechaEMMAC = j.FechaEMMAC,
                                            DNI = j.DNI,
                                            Habilitado = j.Habilitado,
                                            Sexo = s.Descripcion,
                                            Club = j.Clubes.Nombre,
                                            Foto = j.Foto,
                                            NombreRol = RolesEnum.Jugador.ToString()
                                        };

                    return carnetJugador.FirstOrDefault();

                default:
                    return null;
            }
        }
        public Entidades.Usuarios modificarContraseña(Entidades.Usuarios usuarioAModificar)
        {
            context.Entry(usuarioAModificar).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return usuarioAModificar;
        }
        public Entidades.Usuarios getUsuarioById(int usuarioId)
        {
            var usuario = from u in context.Usuarios
                          where u.Id == usuarioId
                          select u;
            return usuario.FirstOrDefault();
        }
        public Entidades.Dto.UsuarioDto getUsuarioByNombre(string nombreUsuario)
        {
            var user = context.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();

            if (user != null)
            {           

            switch (user.RolId)
            {
                case (int)RolesEnum.Jugador:
                    var datos = context.Jugadores.Where(j => j.DNI.Equals(nombreUsuario)).FirstOrDefault();

                    Entidades.Dto.UsuarioDto usuarioDto = new UsuarioDto();

                    usuarioDto.Nombre = datos.Nombre;
                    usuarioDto.Apellido = datos.Apellido;
                    usuarioDto.FechaNac = datos.FechaNac;
                    usuarioDto.FechaEMMAC = datos.FechaEMMAC;
                    usuarioDto.DNI = datos.DNI;
                    usuarioDto.Email = datos.Email;
                    usuarioDto.Telefono = datos.Telefono;
                    usuarioDto.Foto = datos.Foto;
                    usuarioDto.Habilitado = datos.Habilitado;
                    usuarioDto.sexoId = datos.SexoId;

                    return usuarioDto;

                case (int)RolesEnum.Entrenador:
                    var datosE = context.Entrenadores.Where(j => j.DNI.Equals(nombreUsuario)).FirstOrDefault();

                    Entidades.Dto.UsuarioDto usuarioEDto = new UsuarioDto();

                    usuarioEDto.Nombre = datosE.Nombre;
                    usuarioEDto.Apellido = datosE.Apellido;
                    usuarioEDto.FechaNac = datosE.FechaNac;
                    usuarioEDto.FechaEMMAC = datosE.FechaEMMAC;
                    usuarioEDto.DNI = datosE.DNI;
                    usuarioEDto.Email = datosE.Email;
                    usuarioEDto.Telefono = datosE.Telefono;
                    usuarioEDto.Foto = datosE.Foto;
                    usuarioEDto.Habilitado = datosE.Habilitado;

                    return usuarioEDto;

                case (int)RolesEnum.Arbitro:
                    var datosA = context.Arbitros.Where(j => j.DNI.Equals(nombreUsuario)).FirstOrDefault();

                    Entidades.Dto.UsuarioDto usuarioADto = new UsuarioDto();

                    usuarioADto.Nombre = datosA.Nombre;
                    usuarioADto.Apellido = datosA.Apellido;
                    usuarioADto.FechaNac = datosA.FechaNac;
                    usuarioADto.FechaEMMAC = datosA.FechaEMMAC;
                    usuarioADto.DNI = datosA.DNI;
                    usuarioADto.Email = datosA.Email;
                    usuarioADto.Telefono = datosA.Telefono;
                    usuarioADto.Foto = datosA.Foto;
                    usuarioADto.Habilitado = datosA.Habilitado;

                    return usuarioADto;

            }

            }
            return null;

        }

        public void EliminarUsuario(int usuarioId)
        {
            var usuario = context.Usuarios.Find(usuarioId);

            context.Usuarios.Remove(usuario);
            context.SaveChangesAsync();

        }
    }
}
