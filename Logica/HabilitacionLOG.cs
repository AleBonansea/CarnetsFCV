using Entidades.Dto;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class HabilitacionLOG
    {
        Datos.HabilitacionDA habilitacion = new Datos.HabilitacionDA();

        public void Habilitar(int id, int rolId)
        {
            habilitacion.Habilitar(id, rolId);
        }

        public void DesHabilitar(int id, int rolId)
        {
            habilitacion.DesHabilitar(id, rolId);
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosTotales()
        {
            return habilitacion.GetHabilitadosTotales();
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosMasculinos()
        {
            return habilitacion.GetHabilitadosMasculinos();
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosFemeninos()
        {
            return habilitacion.GetHabilitadosFemeninos();
        }
    }
}
