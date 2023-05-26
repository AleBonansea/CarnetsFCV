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
    
    }
}
