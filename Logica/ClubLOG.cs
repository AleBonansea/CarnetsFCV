using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ClubLOG
    {
        Datos.ClubDA club = new Datos.ClubDA();

        public List<Entidades.Dto.ClubDto> getComboClubes()
        {
            return club.getComboClubes();
        }

        public List<Entidades.Dto.ClubDto> getTotalClubes()
        {
            return club.getTotalClubes();
        }

        public List<Entidades.Dto.ClubDto> getBuscadorClubes(string buscar)
        {
            return club.getBuscadorClubes(buscar);
        }
        public Entidades.Clubes eliminarClub(int clubId)
        {
            return club.eliminarClub(clubId);
        }
        public Entidades.Clubes guardarClub(Entidades.Clubes nuevoClub)
        {
            return club.guardarClub(nuevoClub);
        }
        public Entidades.Clubes modificarClub(Entidades.Clubes clubModificado)
        {
            return club.modificarClub(clubModificado);
        }
        public Entidades.Clubes getClub(int clubId)
        {
            return club.getClub(clubId);
        }
        public Entidades.Clubes getClubPorNombre(string nombre)
        {
            return club.getClubPorNombre(nombre);
        }
    }
}
