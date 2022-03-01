using PracticaMigracion.Models;
using PracticaMigracion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PracticaMigracion.Procesos
{
	public class Operaciones
	{
        /***************************************************
           Operaciones relacionadas a las listas 
           de equipos y de jugadores
        ***************************************************/
        public object Listados(string tipo)
        {

            if(tipo == "equipos") 
            {
                var listado = new ListadoDeEquipos();
                listado.ListadoEquipos = Equipos();
                return listado;
            }
            if(tipo == "jugadores") 
            {
                var listado = new ListadoDeJugadores();
                listado.ListadoJugadores = Jugadores();
                return listado;
            }

            throw new Exception();
        }

        private List<Equipos> Equipos()
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var lista_equipos = BD.Equipo.ToList();
                return lista_equipos;
            }
        }

        private List<DatosJugador> Jugadores()
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var lista_jugadores = BD.Jugador.Select(m=> new DatosJugador { 
                    
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Apellido = m.Apellido,
                    Direccion = m.Direccion,
                    FechaNacimiento = m.FechaNacimiento,
                    Pasaporte = m.Pasaporte,
                    Sexo = m.Sexo ? "Masculino" : "Femenino",
                    Estado =m.id_Estado == null ? "No definido":  m.id_Estado.NombreEstado,
                    NombreEquipo = m.Id_Equipo == null ? "No definido" : m.Id_Equipo.Nombre

                }).ToList();
                return lista_jugadores;
            }
        }


        /***************************************************
            Operaciones relacionadas a los jugadores
        ***************************************************/

        public void AgregarJugadorNuevo(Jugadores jugador)
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
               
				if (BD.Estado.Any(m => m.NombreEstado == "Agente Libre") == false)
				{
                    var estado = new TablaDeEstado();
                    estado.FechaDeCreacion = DateTime.Now;
                    estado.NombreEstado = "Agente Libre";
                    BD.Estado.Add(estado);
                    jugador.id_Estado = estado;
                }
				else
				{
                    var estado = BD.Estado.FirstOrDefault(m => m.NombreEstado == "Agente Libre");
                    jugador.id_Estado = estado;
				}
                BD.Jugador.Add(jugador);
                BD.SaveChanges();
            }
        }

        public Jugadores EditarJugador(int id)
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var jugador = BD.Jugador.Find(id);
                if (jugador != null)
                    return jugador;
                else
                    throw new Exception();
            }
        }
        public void ActualizarJugador(Jugadores jugador)
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var editar_jugador = BD.Jugador.Find(jugador.Id);
                editar_jugador.Nombre = jugador.Nombre;
                editar_jugador.Apellido = jugador.Apellido;
                editar_jugador.Pasaporte = jugador.Pasaporte;
                editar_jugador.Sexo = jugador.Sexo;
                editar_jugador.Direccion = jugador.Direccion;
                editar_jugador.FechaNacimiento = jugador.FechaNacimiento;

                BD.SaveChanges();
            }
        }
        public void EliminarJugador(int id)
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var jugador = BD.Jugador.Find(id);
                if (jugador != null)
                {
                    BD.Jugador.Remove(jugador);
                    BD.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        /***************************************************
            Operaciones relacionadas a los equipos 
         ***************************************************/
        public void AgregarEquipoNuevo(Equipos nuevo_equipo)
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                BD.Equipo.Add(nuevo_equipo);
                BD.SaveChanges();
            }
        }

        public Equipos EditarEquipo(int id)
		{
            using (DatabaseContext BD = new DatabaseContext())
            {
                var equipo = BD.Equipo.Find(id);
                if (equipo != null)
                    return equipo;
                else
                    throw new Exception();
            }
        }

        public void ActualizarEquipo(Equipos equipo) 
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var editar_equipo = BD.Equipo.Find(equipo.Id);
                editar_equipo.Nombre = equipo.Nombre;
                editar_equipo.FechaDeCreacion = equipo.FechaDeCreacion;
                editar_equipo.Estado = equipo.Estado;
                editar_equipo.Pais = equipo.Pais;

                BD.SaveChanges();
            }
        }

        public void EliminarEquipo(int id) 
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var equipo = BD.Equipo.Find(id);
                if (equipo != null)
                {
                    BD.Equipo.Remove(equipo);
                    BD.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public DetalleEquipo DetalleEquipo(int id) 
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var equipo = BD.Equipo.FirstOrDefault(m => m.Id.Equals(id));
                if (equipo != null)
                {
                    var detalleEquipo = new DetalleEquipo();
                    detalleEquipo.Id = equipo.Id;
                    detalleEquipo.NombreEquipo = equipo.Nombre;
                    detalleEquipo.Estado = equipo.Estado;
                    detalleEquipo.ListadoJugadores = BD.Jugador.Where(m=>m.Id_Equipo.Id == id).Select(m => new DatosJugador
                    {
                        Nombre = m.Nombre,
                        Apellido = m.Apellido,
                        Sexo = m.Sexo == true ? "Masculino" : "Femenino",
                        Direccion = m.Direccion,
                        FechaNacimiento = m.FechaNacimiento,
                        Pasaporte = m.Pasaporte,
                        Estado = m.id_Estado == null ? "No definido" : m.id_Estado.NombreEstado,
                        NombreEquipo = m.Id_Equipo == null ? "No definido" : m.Id_Equipo.Nombre,
                        Id = m.Id

                    }).ToList();

                    detalleEquipo.ListadoAgregarJugadores = BD.Jugador.Where(m=>m.Id_Equipo.Id != id)
                    .Select(m => new DatosJugador
                    {
                        Nombre = m.Nombre,
                        Apellido = m.Apellido,
                        Sexo = m.Sexo == true ? "Masculino" : "Femenino",
                        Direccion = m.Direccion,
                        FechaNacimiento = m.FechaNacimiento,
                        Pasaporte = m.Pasaporte,
                        Estado = m.id_Estado == null ? "No definido" : m.id_Estado.NombreEstado,
                        NombreEquipo = m.Id_Equipo == null ? "No definido" : m.Id_Equipo.Nombre,
                        Id = m.Id

                    }).ToList();


                    return detalleEquipo;
                }
                else{
                    throw new Exception();
                }
            }
        }


        /***************************************************
         Operaciones Agregar y Eliminar jugadores de un equipo
         ***************************************************/

        public void AgregarJugadorAlEquipo(int id_equipo, int id_jugador) 
        {
            using(DatabaseContext BD = new DatabaseContext()) 
            {

                var equipo = BD.Equipo.Find(id_equipo);
                var jugador = BD.Jugador.Find(id_jugador);
                jugador.Id_Equipo = equipo;
                BD.SaveChanges();
            }
        }

        public void RemoverJugadorDelEquipo(int id_equipo, int id_jugador)
		{
            using(DatabaseContext BD = new DatabaseContext()) 
            {
                //var equipo = BD.Equipo.Find(id_equipo);
                var jugador = BD.Jugador.Include(m=>m.Id_Equipo)
                    .Where(m=>m.Id_Equipo.Id == id_equipo)
                    .FirstOrDefault(m=>m.Id == id_jugador);
                jugador.Id_Equipo = null;
                BD.SaveChanges();
            }
		}

        public void CambiarEstadoJugador(int id_jugador, string estado_jugador) 
        {
            using (DatabaseContext BD = new DatabaseContext())
            {
                var jugador = BD.Jugador.Include(m=>m.id_Estado).FirstOrDefault(m=>m.Id == id_jugador);
                if (BD.Estado.Any(m => m.NombreEstado == estado_jugador) == false)
                {   
                    // si el estado no existe lo agrego
                    var estado = new TablaDeEstado();
                    estado.FechaDeCreacion = DateTime.Now;
                    estado.NombreEstado = estado_jugador;
                    BD.Estado.Add(estado);
                    jugador.id_Estado = estado;
                }
                else
                {
                    // si el estado ya existe lo asocio con el jugador.
                    var estado = BD.Estado.FirstOrDefault(m => m.NombreEstado == estado_jugador);
                    jugador.id_Estado = estado;
                }
                BD.SaveChanges();
            }
        }

    }
}
