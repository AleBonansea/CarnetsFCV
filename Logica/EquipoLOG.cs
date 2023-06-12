using Entidades;
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

        public Entidades.Equipos getEquipo(int idEquipo)
        {
            return equipo.getEquipo(idEquipo);
        }
        public List<Entidades.Dto.EquipoDto> getTotalEquipos(int clubId)
        {
            return equipo.getTotalEquipos(clubId);
        }


        public List<Entidades.Dto.EquipoDto> getBuscadorEquipos(string buscar, int clubId)
        {
            return equipo.getBuscadorEquipos(buscar, clubId);
        }

        public Entidades.Equipos guardarEquipo(Entidades.Equipos equipoNuevo)
        {
            return equipo.guardarEquipo(equipoNuevo);
        }
        public Entidades.Equipos modificarEquipo(Entidades.Equipos equipoModificado)
        {
            return equipo.modificarEquipo(equipoModificado);
        }
        public Entidades.Equipos eliminarEquipo(int equipoId)
        {
            return equipo.eliminarEquipo(equipoId);
        }
    }        
}
