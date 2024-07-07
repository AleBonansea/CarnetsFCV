using Datos;
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
        public Entidades.Sexos getSexo(int id)
        {
            return sexo.getSexo(id);
        }
        public void GuardarSexo(Entidades.Sexos nuevo)
        {
            sexo.GuardarSexo(nuevo);
        }
        public void EliminarSexo(int id)
        {
            sexo.EliminarSexo(id);
        }
        public void ActualizarSexo(Entidades.Sexos modificada)
        {
            sexo.ActualizarSexo(modificada);
        }
    }
}
