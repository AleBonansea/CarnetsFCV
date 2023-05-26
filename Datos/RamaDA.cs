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
    }
}
