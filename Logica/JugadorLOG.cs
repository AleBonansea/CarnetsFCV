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
        public List<Entidades.Dto.JugadorDto> getGVJugadoresTotales()
        {
            return jugador.getGVJugadoresTotales();
        }
        public Entidades.Jugadores guardarJugador(Entidades.Jugadores jugadorNuevo)
        {
            return jugador.guardarJugador(jugadorNuevo);
        }
        public Entidades.Jugadores getJugador(int idJugador)
        {
            return jugador.getJugador(idJugador);
        }
        public Entidades.Jugadores modificarJugador(Entidades.Jugadores jugadorModificado)
        {
            return jugador.modificarJugador(jugadorModificado);
        }
        public Entidades.Jugadores eliminarJugador(int jugadorId)
        {
            return jugador.eliminarJugador(jugadorId);
        }

    }
}
