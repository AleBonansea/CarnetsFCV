﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Entidades.Dto.DivisionDto> getDivisiones()
        {
            return division.getDivisiones();
        }

    }
}
