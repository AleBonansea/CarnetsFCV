﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Dto;

namespace Datos
{
    public class JugadorDA
    {
        Entidades.Modelo context = new Entidades.Modelo();

        public List<Entidades.Dto.JugadorDto> getGVJugadores(int clubId)
        {
            var listaJugadores = from j in context.Jugadores
                                 where j.ClubId == clubId
                                 select new Entidades.Dto.JugadorDto { 
                                     Id = j.Id,
                                     Club = j.Clubes.Nombre,
                                     Equipo = j.Equipos.Nombre,
                                     División = j.Equipos.Divisiones.Descripcion,
                                     Nombre = j.Nombre,
                                     Apellido = j.Apellido,
                                     FechaNac = j.FechaNac,
                                     FechaEMMAC = j.FechaEMMAC,
                                     DNI = j.DNI,
                                     Email = j.Email,
                                     Telefono = j.Telefono,
                                     Sexo = j.Sexo,
                                     Habilitado = j.Habilitado
                                 };

            return listaJugadores.ToList();
        }

        public List<Entidades.Dto.JugadorDto> getGVJugadoresTotales()
        {
            var listaJugadores = from j in context.Jugadores
                                 select new Entidades.Dto.JugadorDto
                                 {
                                     Id = j.Id,
                                     Club = j.Clubes.Nombre,
                                     Equipo = j.Equipos.Nombre,
                                     División = j.Equipos.Divisiones.Descripcion,
                                     Nombre = j.Nombre,
                                     Apellido = j.Apellido,
                                     FechaNac = j.FechaNac,
                                     FechaEMMAC = j.FechaEMMAC,
                                     DNI = j.DNI,
                                     Email = j.Email,
                                     Telefono = j.Telefono,
                                     Sexo = j.Sexo,
                                     Habilitado = j.Habilitado
                                 };

            return listaJugadores.ToList();
        }
        public Entidades.Jugadores guardarJugador(Entidades.Jugadores jugadorNuevo)
        {
            context.Jugadores.Add(jugadorNuevo);

            context.SaveChanges();

            return jugadorNuevo;
        }
        public Entidades.Jugadores getJugador(int idJugador)
        {
            var jugador = from j in context.Jugadores
                             where j.Id == idJugador
                          select j;
            return jugador.FirstOrDefault();
        }
        public Entidades.Jugadores modificarJugador(Entidades.Jugadores jugadorModificado)
        {
            context.Entry(jugadorModificado).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return jugadorModificado;
        }
        public Entidades.Jugadores eliminarJugador(int jugadorId)
        {
            Entidades.Jugadores jugador = context.Jugadores.Find(jugadorId);
            context.Jugadores.Remove(jugador);
            context.SaveChanges();
            return jugador;
        }
    }
}
