using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RamaLOG
    {
        Datos.RamaDA rama = new Datos.RamaDA();
        
        public List<Ramas> getRamas()
        {
            return rama.getRamas();
        }
        public Ramas getRama(int id)
        {
            return rama.getRama(id);
        }
        public void GuardarRama(Entidades.Ramas nuevo)
        {
            rama.GuardarRama(nuevo);
        }
        public void EliminarRama(int id)
        {
            rama.EliminarRama(id);
        }
        public void ActualizarRama(Entidades.Ramas modificada)
        {
            rama.ActualizarRama(modificada);
        }

        public List<Ramas> getRamasPorClub(int clubId)
        {
            return rama.getRamasPorClub(clubId);
        }
    }
}
