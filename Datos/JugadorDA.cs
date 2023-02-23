using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Dto;

namespace Datos
{
    public class JugadorDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.JugadorDto> getGVJugadores(int clubId)
        {
            var listaJugadores = from j in context.Jugadores
                                 where j.ClubId == clubId
                                 select new Entidades.Dto.JugadorDto { 
                                 Club = j.Clubes.Nombre,
                                 Equipo = j.Equipos.Nombre,
                                 División = j.Equipos.Divisiones.Descripcion,
                                 Nombre = j.Nombre,
                                 Apellido = j.Apellido,
                                 FechaNac = j.FechaNac,
                                 FechaEMMAC = j.FechaEMMAC,
                                 DNI = j.DNI,
                                 Email = j.Email,
                                 Telefono = j.Telefono,
                                 Sexo = j.Sexo,
                                 Habilitado = j.Habilitado
                                 };

            return listaJugadores.ToList();
        }
    }
}
