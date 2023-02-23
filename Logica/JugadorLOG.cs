using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class JugadorLOG
    {
        Datos.JugadorDA jugador = new Datos.JugadorDA();

        public List<Entidades.Dto.JugadorDto> getGVJugadores(int clubId)
        {
            return jugador.getGVJugadores(clubId);
        }
    }
}
