using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EquipoLOG
    {
        Datos.EquipoDA equipo = new Datos.EquipoDA();

        public List<Entidades.Dto.EquipoDto> getComboEquipos()
        {
            return equipo.getComboEquipos();
        }
        public List<Entidades.Dto.EquipoDto> getTotalEquipos(int clubId)
        {
            return equipo.getTotalEquipos(clubId);
    }

        public List<Entidades.Dto.EquipoDto> getBuscadorEquipos(string buscar, int clubId)
        {
            return equipo.getBuscadorEquipos(buscar, clubId);
        }
    }        
}
