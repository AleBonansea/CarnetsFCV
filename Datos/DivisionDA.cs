using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DivisionDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.DivisionDto> getComboDivisiones(int clubId, int ramaId)
        {
            var listaDivisiones = from d in context.Divisiones
                                  from e in context.Equipos
                                  from c in context.Clubes
                                  where c.Id == clubId
                                  && e.RamaId == ramaId
                                  && d.Id == e.DivisionId
                              select new Entidades.Dto.DivisionDto
                              {
                                  Id = d.Id,
                                  Descripcion = d.Descripcion
                              };

            return listaDivisiones.ToList();
        }

    }
}
