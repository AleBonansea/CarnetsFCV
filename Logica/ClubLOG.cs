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
    }
}
