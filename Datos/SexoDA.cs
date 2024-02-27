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
    }
}