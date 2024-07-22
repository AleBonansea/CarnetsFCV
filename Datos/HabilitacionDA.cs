using Entidades;
using Entidades.Dto;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class HabilitacionDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public void Habilitar(int id, int rolId)
        {
            var añoActual = DateTime.Now.Year;
            Entidades.Habilitaciones ultimaHabilitacion = context.Habilitaciones
                .Where(h => h.EntidadId.Equals(id))
                .OrderByDescending(h => h.Fecha)
                .FirstOrDefault();

            if (ultimaHabilitacion != null && ultimaHabilitacion.Fecha.Year == añoActual)
            {
                if (ultimaHabilitacion.Vigente == true)
                {
                    ultimaHabilitacion.Vigente = false;
                }
                else
                {
                    ultimaHabilitacion.Vigente = true;
                }    
                context.Entry(ultimaHabilitacion).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                var nuevaHabilitacion = new Habilitaciones()
                {
                    Fecha = DateTime.Now,
                    EntidadId = id,
                    RolId = rolId,
                    Vigente = true
                };

                context.Habilitaciones.Add(nuevaHabilitacion);
            }

            context.SaveChanges();
        }

        public void DesHabilitar(int id, int rolId)
        {
            var añoActual = DateTime.Now.Year;
            Entidades.Habilitaciones ultimaHabilitacion = context.Habilitaciones
                .Where(h => h.EntidadId.Equals(id))
                .OrderByDescending(h => h.Fecha)
                .FirstOrDefault();

            ultimaHabilitacion.Vigente = false;
               
            context.Entry(ultimaHabilitacion).State = System.Data.Entity.EntityState.Modified;
           
            

            context.SaveChanges();
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosTotales()
        {
            var cantidadesPorAno = context.Habilitaciones.Where(h => h.Vigente)
                                    .GroupBy(h => h.Fecha.Year)
                                    .Select(g => new HabilitadosPorAnoDto
                                    {
                                        Year = g.Key,
                                        Total = g.Count()
                                    })
                                    .OrderBy(dto => dto.Year)
                                    .ToList();

            return cantidadesPorAno;
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosMasculinos()
        {
            var cantidadesPorAnoMasculino = context.Habilitaciones.Where(h => h.Vigente)
                                                .Join(context.Jugadores,
                                                      h => h.EntidadId,
                                                      j => j.Id,
                                                      (h, j) => new { Habilitacion = h, Jugador = j })
                                                .Where(x => x.Jugador.SexoId == (int)SexosEnum.Masculino)
                                                .GroupBy(x => x.Habilitacion.Fecha.Year)
                                                .Select(g => new HabilitadosPorAnoDto
                                                {
                                                    Year = g.Key,
                                                    Total = g.Count()
                                                })
                                                .OrderBy(dto => dto.Year)
                                                .ToList();

            return cantidadesPorAnoMasculino;
        }

        public List<HabilitadosPorAnoDto> GetHabilitadosFemeninos()
        {
            var cantidadesPorAnoFemenino = context.Habilitaciones.Where(h => h.Vigente)
                                                .Join(context.Jugadores,
                                                      h => h.EntidadId,
                                                      j => j.Id,
                                                      (h, j) => new { Habilitacion = h, Jugador = j })
                                                .Where(x => x.Jugador.SexoId == (int)SexosEnum.Femenino) 
                                                .GroupBy(x => x.Habilitacion.Fecha.Year)
                                                .Select(g => new HabilitadosPorAnoDto
                                                {
                                                    Year = g.Key,
                                                    Total = g.Count()
                                                })
                                                .OrderBy(dto => dto.Year)
                                                .ToList();

            return cantidadesPorAnoFemenino;
        }
    }
}
