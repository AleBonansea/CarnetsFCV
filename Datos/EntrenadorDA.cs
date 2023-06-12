using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EntrenadorDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Entrenadores> getTotalEntrenadores()
        {
            var entrenadores = from e in context.Entrenadores
                                                        select e;
            return entrenadores.ToList();
        }
        public List<Entidades.Entrenadores> getBuscadorEntrenadores(string buscar)
        {
            var listaEntrenadores = from e in context.Entrenadores
                                    where e.Nombre.Contains(buscar)
                                       select e;


            return listaEntrenadores.ToList();
        }
        public Entidades.Entrenadores guardarEntrenador(Entidades.Entrenadores entrenadorNuevo)
        {
            context.Entrenadores.Add(entrenadorNuevo);

            context.SaveChanges();

            return entrenadorNuevo;
        }
        public Entidades.Entrenadores modificarEntrenador(Entidades.Entrenadores entrenadorModificado)
        {
            context.Entry(entrenadorModificado).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return entrenadorModificado;
        }
        public Entidades.Entrenadores eliminarEntrenador(int entrenadorId)
        {
            Entidades.Entrenadores entrenador = context.Entrenadores.Find(entrenadorId);
            context.Entrenadores.Remove(entrenador);
            context.SaveChanges();
            return entrenador;
        }
        public Entidades.Entrenadores getEntrenador(int idEntrenador)
        {
            var entrenador = from e in context.Entrenadores
                         where e.Id == idEntrenador
                         select e;
            return entrenador.FirstOrDefault();
        }
    }
}
