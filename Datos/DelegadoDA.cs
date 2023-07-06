using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DelegadoDA
    {
        Entidades.Modelo context = new Entidades.Modelo();
        public Entidades.Delegados guardarDelegado(Entidades.Delegados nuevoDelegado)
        {
            context.Delegados.Add(nuevoDelegado);

            context.SaveChanges();

            return nuevoDelegado;
        }
        public Entidades.Delegados modificarDelegado(Entidades.Delegados delegadoModificado)
        {
            context.Entry(delegadoModificado).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return delegadoModificado;
        }
        public Entidades.Delegados getDelegado(int clubId)
        {
            var delegado = from d in context.Delegados
                           where d.ClubId == clubId
                           select d;

            return delegado.FirstOrDefault();
        }
    }
}
