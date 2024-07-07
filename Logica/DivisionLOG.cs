using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DivisionLOG
    {
        Datos.DivisionDA division = new Datos.DivisionDA();

        public List<Entidades.Dto.DivisionDto> getComboDivisiones(int clubId, int ramaId)
        {
            return division.getComboDivisiones(clubId,ramaId);
        }

        public List<Entidades.Divisiones> getDivisiones()
        {
            return division.getDivisiones();
        }
        public Entidades.Divisiones getDivision(int id)
        {
            return division.getDivision(id);
        }
        public Entidades.Divisiones GuardarDivision(Entidades.Divisiones divisionNueva)
        {
            return division.GuardarDivision(divisionNueva);
        }

        public void EliminarDivision(int id)
        {
            division.EliminarDivision(id);
        }
        public void ActualizarDivision(Entidades.Divisiones modificada)
        {
            division.ActualizarDivision(modificada);
        }

        public List<Divisiones> getDivisionesPorClub(int clubId)
        {
            return division.getDivisionesPorClub(clubId);
        }
    }
}
