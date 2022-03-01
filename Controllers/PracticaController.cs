using Microsoft.AspNetCore.Mvc;
using PracticaMigracion.Models;
using PracticaMigracion.Procesos;

namespace PracticaMigracion.Controllers
{
	public class PracticaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		// *******************************************
		// ***************** Jugadores ***************
		// *******************************************
		public IActionResult ListadoJugadores()
		{
			Operaciones operaciones = new Operaciones();
			return View(operaciones.Listados("jugadores"));
		}

		[HttpGet]
		public IActionResult AgregarJugador() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult AgregarJugador(Jugadores jugadorNuevo) 
		{
			Operaciones operaciones = new Operaciones();
			operaciones.AgregarJugadorNuevo(jugadorNuevo);
			return RedirectToAction("ListadoJugadores");
		}

		[HttpGet]
		public IActionResult EditarJugador(int id) 
		{
			Operaciones operaciones = new Operaciones();
			return View(operaciones.EditarJugador(id));
		}

		[HttpPost]
		public IActionResult EditarJugador(Jugadores jugador) 
		{
			Operaciones operaciones = new Operaciones();
			operaciones.ActualizarJugador(jugador);
			return RedirectToAction("ListadoJugadores");
		}

		public IActionResult EliminarJugador(int id) 
		{
			Operaciones operaciones = new Operaciones();
			operaciones.EliminarJugador(id);
			return RedirectToAction("ListadoJugadores");
		}


		// *******************************************
		// ***************** Equipos *****************
		// *******************************************

		public IActionResult ListadoEquipos() 
		{
			Operaciones operaciones = new Operaciones();
			return View(operaciones.Listados("equipos"));
		}

		[HttpGet] 
		public IActionResult AgregarEquipos() 
		{
			CargarPaises cargarPaises = new CargarPaises();
			ViewData["Paises"] = cargarPaises.ListadoDePaises();
			return View();
		}

		[HttpPost]
		public IActionResult AgregarEquipos(Equipos nuevoEquipo) 
		{
			Operaciones operaciones = new Operaciones();
			operaciones.AgregarEquipoNuevo(nuevoEquipo);
			return RedirectToAction("ListadoEquipos");
		}


		[HttpGet]
		public IActionResult EditarEquipo(int id) 
		{
			CargarPaises cargarPaises = new CargarPaises();
			ViewData["Paises"] = cargarPaises.ListadoDePaises();
			Operaciones operaciones = new Operaciones();
			return View(operaciones.EditarEquipo(id));
		}

		[HttpPost]
		public IActionResult EditarEquipo(Equipos editarEquipo)
		{
			Operaciones op = new Operaciones();
			op.ActualizarEquipo(editarEquipo);
			return RedirectToAction("ListadoEquipos");
		}

		public IActionResult EliminarEquipo(int id) 
		{

			Operaciones op = new Operaciones();
			op.EliminarEquipo(id);
			return RedirectToAction("ListadoEquipos");
		}

		public IActionResult DetalleEquipo(int id) 
		{
			Operaciones op = new Operaciones();
			return View(op.DetalleEquipo(id));
		}


		// *******************************************************************
		// ******** Agregar Y Eliminar Jugadores de un Equipo *****************
		// ********************************************************************

		public IActionResult AgregarJugadorAlGrupo(int id_equipo, int id_jugador) 
		{
			Operaciones op = new Operaciones();
			op.AgregarJugadorAlEquipo(id_equipo, id_jugador);
			return RedirectToAction("DetalleEquipo", new { id = id_equipo });
		}

		public IActionResult RemoverJugadorDelEquipo(int id_equipo, int id_jugador) 
		{
			Operaciones op = new Operaciones();
			op.RemoverJugadorDelEquipo(id_equipo, id_jugador);
			return RedirectToAction("DetalleEquipo", new { id = id_equipo });
		}

		public IActionResult CambiarEstadoJugador(int id_jugador, int id_equipo, string estado_jugador) 
		{
			Operaciones op = new Operaciones();
			op.CambiarEstadoJugador(id_jugador, estado_jugador);
			return RedirectToAction("DetalleEquipo", new { id = id_equipo });
		}

	}
}
