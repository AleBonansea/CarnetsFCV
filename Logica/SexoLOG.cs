using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SexoLOG
    {
        Datos.SexoDA sexo = new Datos.SexoDA();

        public List<Sexos> getSexos()
        {
            return sexo.getSexos();
        }
    }
}
