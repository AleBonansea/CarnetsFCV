using Entidades;
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

        public List<Entidades.Divisiones> getDivisiones()
        {
            var listaDivisiones = context.Divisiones.ToList();

            return listaDivisiones;
        }

        public Entidades.Divisiones getDivision(int id)
        {
            var division = context.Divisiones.Find(id);

            return division;
        }
        public Entidades.Divisiones GuardarDivision(Entidades.Divisiones divisionNueva)
        {
            context.Divisiones.Add(divisionNueva);

            context.SaveChanges();

            return divisionNueva;
        }
        public void EliminarDivision(int id)
        {
            Entidades.Divisiones division = context.Divisiones.Find(id);

            context.Divisiones.Remove(division);

            context.SaveChanges();
        }
        public void ActualizarDivision(Entidades.Divisiones modificada)
        {
            context.Entry(modificada).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public List<Divisiones> getDivisionesPorClub(int clubId)
        {
            var divisiones = context.Equipos
                .Where(eq => eq.ClubId == clubId)
                .Select(eq => eq.Divisiones)
                .Distinct()
                .Select(division => new
                {
                    Id = division.Id,
                    Descripcion = division.Descripcion
                })
                .ToList()
                .Select(d => new Divisiones
                {
                    Id = d.Id,
                    Descripcion = d.Descripcion
                })
                .ToList();

            return divisiones;
        }
    }
}
