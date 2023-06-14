using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ArbitroDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Arbitros> getTotalArbitros()
        {
            var arbitros = from e in context.Arbitros
                               select e;
            return arbitros.ToList();
        }
        public List<Entidades.Arbitros> getBuscadorArbitros(string buscar)
        {
            var listaArbitros = from e in context.Arbitros
                                where e.Nombre.Contains(buscar)
                                    select e;


            return listaArbitros.ToList();
        }
        public Entidades.Arbitros guardarArbitro(Entidades.Arbitros arbitroNuevo)
        {
            context.Arbitros.Add(arbitroNuevo);

            context.SaveChanges();

            return arbitroNuevo;
        }
        public Entidades.Arbitros modificarArbitro(Entidades.Arbitros arbitroModificado)
        {
            context.Entry(arbitroModificado).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return arbitroModificado;
        }
        public Entidades.Arbitros eliminarArbitro(int arbitroId)
        {
            Entidades.Arbitros arbitro = context.Arbitros.Find(arbitroId);
            context.Arbitros.Remove(arbitro);
            context.SaveChanges();
            return arbitro;
        }
        public Entidades.Arbitros getArbitro(int idArbitro)
        {
            var arbitro = from e in context.Arbitros
                             where e.Id == idArbitro
                             select e;
            return arbitro.FirstOrDefault();
        }
        public List<ArbitroDto> cargarExcel()
        {
            var arbitro = from e in context.Arbitros
                               select new ArbitroDto
                               {
                                   Nombre = e.Nombre,
                                   Apellido = e.Apellido,
                                   FechaNac = e.FechaNac,
                                   FechaEMMAC = e.FechaEMMAC,
                                   DNI = e.DNI,
                                   Email = e.Email,
                                   Telefono = e.Telefono,
                                   Habilitado = e.Habilitado
                               };
            return arbitro.ToList();
        }
    }
}
