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
                                  Nombre = e.Nombre
                              };

            return listaEquipos.ToList();
        }
    }
}
