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
        public Entidades.Clubes eliminarClub(int clubId)
        {
            Entidades.Clubes club = context.Clubes.Find(clubId);
            Entidades.Delegados delegado = context.Delegados.SingleOrDefault(d => d.ClubId == clubId);

            context.Delegados.Remove(delegado);

            context.Clubes.Remove(club);
            context.SaveChanges();
            return club;
        }
        public Entidades.Clubes guardarClub(Entidades.Clubes nuevoClub)
        {
            context.Clubes.Add(nuevoClub);

            context.SaveChanges();

            return nuevoClub;
        }
        public Entidades.Clubes modificarClub(Entidades.Clubes clubModificado)
        {
            context.Entry(clubModificado).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return clubModificado;
        }
        public Entidades.Clubes getClub(int clubId)
        {
            var club = from c in context.Clubes
                       where c.Id == clubId
                       select c;

            return club.FirstOrDefault();
        }
        public Entidades.Clubes getClubPorNombre(string nombre)
        {
            var club = from c in context.Clubes
                       where c.Nombre == nombre
                       select c;

            return club.FirstOrDefault();
        }
    }
}
