using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ArbitroLOG
    {
        Datos.ArbitroDA arbitro = new Datos.ArbitroDA();

        public List<Entidades.Arbitros> getTotalArbitros()
        {
            return arbitro.getTotalArbitros();
        }
        public List<Entidades.Arbitros> getBuscadorArbitros(string buscar)
        {
            return arbitro.getBuscadorArbitros(buscar);
        }
        public Entidades.Arbitros guardarArbitro(Entidades.Arbitros arbitroNuevo)
        {
            return arbitro.guardarArbitro(arbitroNuevo);
        }
        public Entidades.Arbitros modificarArbitro(Entidades.Arbitros arbitroModificado)
        {
            return arbitro.modificarArbitro(arbitroModificado);
        }
        public Entidades.Arbitros eliminarArbitro(int arbitroId)
        {
            return arbitro.eliminarArbitro(arbitroId);
        }
        public Entidades.Arbitros getArbitro(int idArbitro)
        {
            return arbitro.getArbitro(idArbitro);
        }
        public List<ArbitroDto> cargarExcel()
        {
            return arbitro.cargarExcel();
        }
    }
}
