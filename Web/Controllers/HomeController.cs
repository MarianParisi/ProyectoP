using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
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
			List<Exercise> exerciseList = db.Exercise.ToList();
			ViewBag.Exercises = exerciseList;
			return View();
		}

		public ActionResult NivelAvanzado()
		{
			List<Exercise> exerciseList = db.Exercise.ToList();
			ViewBag.Exercises = exerciseList;
			return View();
		}
		public ActionResult Funcional()
		{
			return View();
		}
		public ActionResult SeleccionNivel()
		{
			return View();
		}
		public ActionResult Contacto()
		{
			ViewBag.Message = "Complete los siguientes campos y responderemos a la brevedad";

			return View();
		}
		public ActionResult Rutina()
		{
			User user = (User) Session["LoggedUser"];
			ViewBag.userName = user.Name;
			return View();
		}
		public ActionResult RutinaIntermedia()
		{
			User user = (User)Session["LoggedUser"];
			ViewBag.userName = user.Name;
			return View();
		}
		public ActionResult RutinaAvanzada()
		{
			User user = (User)Session["LoggedUser"];
			ViewBag.userName = user.Name;
			return View();
		}
		[HttpPost]
		public ActionResult RecibirContacto(string nombre,
								string email, string mensaje)
		{
			
			ViewBag.Nombre = nombre;
			ViewBag.Email = email;
			ViewBag.Mensaje = mensaje;

			//Definimos la conexión al servidor SMTP que vamos a usar
			//para mandar el mail. Hay que buscar como es en nuestro proveedor.
			SmtpClient clienteSmtp = new SmtpClient("smtp.mail.yahoo.com.ar", 587);
			clienteSmtp.Credentials = new NetworkCredential("nemesis_33_22@yahoo.com.ar", "");
			clienteSmtp.EnableSsl = true;

			//Generamos el objeto MAIL a enviar
			MailMessage mailParaAdministrador = new MailMessage();
			mailParaAdministrador.From = new MailAddress("nemesis_33_22@yahoo.com.ar", "technoloshe");
			mailParaAdministrador.To.Add("nemesis_33_22@yahoo.com.ar");
			mailParaAdministrador.Subject = "Nuevo contacto";
			mailParaAdministrador.Body = "Te contactó: " + nombre + "(" + email + ").\nSu mensaje fue: " + mensaje;

			//mandamos el mail
			clienteSmtp.Send(mailParaAdministrador);

			//vamos a mandarle un mail al usuario que nos dejó el contacto
			MailMessage mailAUsuario = new MailMessage();
			mailAUsuario.From = new MailAddress("nemesis_33_22@yahoo.com.ar", "technoloshe");
			mailAUsuario.To.Add(email);
			mailAUsuario.Subject = "Gracias por contactarte con nosotros!";
			mailAUsuario.IsBodyHtml = true;
			mailAUsuario.Body = "Hola <b>" + nombre + "</b>!<br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + email + "<br>Mensaje: " + mensaje + "<br><br>Saludos!!!<br><b>Do it Functional</b>";

			//usamos el mismo objeto cliente smtp que creamos antes
			clienteSmtp.Send(mailAUsuario);

			return View("Index");
		}

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

			Level level = db.Level.FirstOrDefault(u => u.Description.Equals("Inicial"));
			ViewBag.level = level;
			
			return View();
		}
		[HttpPost]

		public ActionResult RutinaIntermedia(int Ejercicio1, int Ejercicio2, int Ejercicio3, int Ejercicio4)

		{
			Exercise ejerciciosSeleccionados1 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio1));
			Exercise ejerciciosSeleccionados2 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio2));
			Exercise ejerciciosSeleccionados3 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio3));
			Exercise ejerciciosSeleccionados4 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio4));

			ViewBag.ejerciciosRutina1 = ejerciciosSeleccionados1;
			ViewBag.ejerciciosRutina2 = ejerciciosSeleccionados2;
			ViewBag.ejerciciosRutina3 = ejerciciosSeleccionados3;
			ViewBag.ejerciciosRutina4 = ejerciciosSeleccionados4;

			
			Level level = db.Level.FirstOrDefault(u => u.Description.Equals("Intermedio"));
			ViewBag.level = level;

			return View();
		}
		[HttpPost]

		public ActionResult RutinaAvanzada(int Ejercicio1, int Ejercicio2, int Ejercicio3, int Ejercicio4, int Ejercicio5)

		{
			Exercise ejerciciosSeleccionados1 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio1));
			Exercise ejerciciosSeleccionados2 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio2));
			Exercise ejerciciosSeleccionados3 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio3));
			Exercise ejerciciosSeleccionados4 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio4));
			Exercise ejerciciosSeleccionados5 = db.Exercise.FirstOrDefault(u => u.ID.Equals(Ejercicio5));

			ViewBag.ejerciciosRutina1 = ejerciciosSeleccionados1;
			ViewBag.ejerciciosRutina2 = ejerciciosSeleccionados2;
			ViewBag.ejerciciosRutina3 = ejerciciosSeleccionados3;
			ViewBag.ejerciciosRutina4 = ejerciciosSeleccionados4;
			ViewBag.ejerciciosRutina5 = ejerciciosSeleccionados5;

			Level level = db.Level.FirstOrDefault(u => u.Description.Equals("Avanzado"));
			ViewBag.level = level;

			return View();
		}
	}
}