using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RamaDA
    {
        Entidades.Modelo context = new Entidades.Modelo();
    
        public List<Ramas> getRamas()
        {
            var listaRamas = from r in context.Ramas
                             select r;

            return listaRamas.ToList();
        }
        public Ramas getRama(int id)
        {
            return context.Ramas.Find(id);
        }
        public void GuardarRama(Entidades.Ramas nuevo)
        {
            context.Ramas.Add(nuevo);

            context.SaveChanges();
        }
        public void EliminarRama(int id)
        {
            Entidades.Ramas rama = context.Ramas.Find(id);

            context.Ramas.Remove(rama);

            context.SaveChanges();
        }
        public void ActualizarRama(Entidades.Ramas modificada)
        {
            context.Entry(modificada).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
        public List<Ramas> getRamas(int clubId)
        {
            var listaRamas = from r in context.Ramas
                             select r;

            return listaRamas.ToList();
        }
        public List<Ramas> getRamasPorClub(int clubId)
        {
            var ramas = context.Equipos
        .Where(eq => eq.ClubId == clubId)
        .Select(eq => eq.Ramas)
        .Distinct()
        .Select(rama => new
        {
            Id = rama.Id,
            Descripcion = rama.Descripcion
        })
        .ToList()
        .Select(r => new Ramas
        {
            Id = r.Id,
            Descripcion = r.Descripcion
        })
        .ToList();

            return ramas;
        }
    }
}
