using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DelegadoLOG
    {
        Datos.DelegadoDA delegado = new Datos.DelegadoDA();

        public Entidades.Delegados guardarDelegado(Entidades.Delegados nuevoDelegado)
        {
            return delegado.guardarDelegado(nuevoDelegado);
        }
        public Entidades.Delegados modificarDelegado(Entidades.Delegados delegadoModificado)
        {
            return delegado.modificarDelegado(delegadoModificado);
        }
        public Entidades.Delegados getDelegado(int clubId)
        {
            return delegado.getDelegado(clubId);
        }
    }
}
