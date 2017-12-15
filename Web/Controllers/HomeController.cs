using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.DAL;

namespace Web.Controllers
{
	public class HomeController : Controller
	{
	    private TrainingContext db = new TrainingContext();
   
		public ActionResult Index()
		{
            ViewBag.Vista = "Index";
			return View();
		}

		public ActionResult NivelInicial()
		{
		    List<Exercise> exerciseList = db.Exercise.ToList();
		    ViewBag.Exercises = exerciseList;
			

			return View();
		}

		public ActionResult NivelIntermedio()
		{
			return View();
		}

		public ActionResult NivelAvanzado()
		{
			return View();
		}
		public ActionResult Funcional()
		{
			return View();
		}
		public ActionResult Rutina()
		{
			List<Level> levelList = db.Level.ToList();
			ViewBag.level = levelList;
			return View();
		}
		public ActionResult Contacto()
		{
			ViewBag.Message = "Complete los siguientes campos para registrarse";

			return View();
		}
		//[HttpPost]
		//public ActionResult IngresoUsuario(string nombre, string mail)
		//{
		//	ViewBag.Nombre = nombre;
		//	ViewBag.Mail = mail;
			
		//	return View("Index");
		//}



		//[HttpPost]
		//public ActionResult CalcularIMC(decimal estatura, decimal pesoActual)
		//{
		//	decimal IMC;
		//	IMC= pesoActual / (estatura * estatura);
		//	ViewBag.IMC = IMC;
		//	return View();
		//}

		[HttpPost]
		public ActionResult Rutina(int Ejercicio1, int Ejercicio2, int Ejercicio3)

		{
			Exercise ejerciciosSeleccionados1 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio1));
			Exercise ejerciciosSeleccionados2 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio2));
			Exercise ejerciciosSeleccionados3 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio3));


			ViewBag.ejerciciosRutina1 = ejerciciosSeleccionados1;
			ViewBag.ejerciciosRutina2 = ejerciciosSeleccionados2;
			ViewBag.ejerciciosRutina3 = ejerciciosSeleccionados3;
			return View("Rutina");
		}
	}
}