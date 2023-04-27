using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EquipoDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.EquipoDto> getComboEquipos()
        {
            var listaEquipos = from e in context.Equipos
                              select new Entidades.Dto.EquipoDto
                              {
                                  Id = e.Id,
                                  NombreEquipo = e.Nombre
                              };

            return listaEquipos.ToList();
        }
        public List<Entidades.Dto.EquipoDto> getTotalEquipos(int clubId)
        {
            var listaEquipos = from e in context.Equipos
                               where e.ClubId == clubId
                              select new Entidades.Dto.EquipoDto
                              {
                                  NombreClub = e.Clubes.Nombre,
                                  NombreEquipo = e.Nombre,
                                  Division = e.Divisiones.Descripcion,
                                  Rama = e.Ramas.Descripcion
                              };

            return listaEquipos.ToList();
        }

        public List<Entidades.Dto.EquipoDto> getBuscadorEquipos(string buscar, int clubId)
        {
            var listaEquipos = from e in context.Equipos
                              where e.Nombre.Contains(buscar)
                              && e.ClubId == clubId
                              select new Entidades.Dto.EquipoDto
                              {
                                  NombreClub = e.Clubes.Nombre,
                                  NombreEquipo = e.Nombre,
                                  Division = e.Divisiones.Descripcion,
                                  Rama = e.Ramas.Descripcion
                              };
                              

            return listaEquipos.ToList();
        }
    }
}

