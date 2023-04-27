using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClubDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.ClubDto> getComboClubes()
        {
            var listaClubes = from c in context.Clubes
                                 select new Entidades.Dto.ClubDto
                                 {
                                     Id = c.Id,
                                     Nombre = c.Nombre
                                 };

            return listaClubes.ToList();
        }

        public List<Entidades.Dto.ClubDto> getTotalClubes()
        {
            var listaClubes = from c in context.Clubes
                              from d in context.Delegados
                              where c.Id == d.ClubId
                              select new Entidades.Dto.ClubDto
                              {
                                  Id = c.Id,
                                  Nombre = c.Nombre,
                                  Domicilio = c.Domicilio,
                                  Delegado = d.Nombre + " " + d.Apellido,
                                  Telefono = d.Telefono,
                                  Email = d.Email
                              };

            return listaClubes.ToList();
        }

        public List<Entidades.Dto.ClubDto> getBuscadorClubes(string buscar)
        {
            var listaClubes = from c in context.Clubes
                              from d in context.Delegados
                              where c.Id == d.ClubId
                              && c.Nombre.Contains(buscar)
                              select new Entidades.Dto.ClubDto
                              {
                                  Id = c.Id,
                                  Nombre = c.Nombre,
                                  Domicilio = c.Domicilio,
                                  Delegado = d.Nombre + " " + d.Apellido,
                                  Telefono = d.Telefono,
                                  Email = d.Email
                              };

            return listaClubes.ToList();
        }
    }
}
