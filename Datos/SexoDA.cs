using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class SexoDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Sexos> getSexos()
        {
            var listaSexos = from r in context.Sexos
                             select r;

            return listaSexos.ToList();
        }
        public Entidades.Sexos getSexo(int id)
        {
            return context.Sexos.Find(id);
        }
        public void GuardarSexo(Entidades.Sexos nuevo)
        {
            context.Sexos.Add(nuevo);

            context.SaveChanges();
        }
        public void EliminarSexo(int id)
        {
            Entidades.Sexos sexo = context.Sexos.Find(id);

            context.Sexos.Remove(sexo);

            context.SaveChanges();
        }
        public void ActualizarSexo(Entidades.Sexos modificada)
        {
            context.Entry(modificada).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}