using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EntrenadorLOG
    {
        Datos.EntrenadorDA entrenador = new Datos.EntrenadorDA();

        public List<Entidades.Entrenadores> getTotalEntrenadores()
        {
            return entrenador.getTotalEntrenadores();
        }
        public List<Entidades.Entrenadores> getBuscadorEntrenadores(string buscar)
        {
            return entrenador.getBuscadorEntrenadores(buscar);
        }
        public Entidades.Entrenadores guardarEntrenador(Entidades.Entrenadores entrenadorNuevo)
        {
            return entrenador.guardarEntrenador(entrenadorNuevo);
        }
        public Entidades.Entrenadores modificarEntrenador(Entidades.Entrenadores entrenadorModificado)
        {
            return entrenador.modificarEntrenador(entrenadorModificado);
        }
        public Entidades.Entrenadores eliminarEntrenador(int entrenadorId)
        {
            return entrenador.eliminarEntrenador(entrenadorId);
        }
        public Entidades.Entrenadores getEntrenador(int idEntrenador)
        {
            return entrenador.getEntrenador(idEntrenador);
        }
        public List<EntrenadorDto> cargarExcel()
        {
            return entrenador.cargarExcel();
        }
    }
}
