using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.DAL;

namespace Web.Controllers
{
    public class UserController : Controller
    {
		private TrainingContext db = new TrainingContext();

		// GET: User
		public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
		public ActionResult Login()
		{
			return View();
		}

		/// <summary>
		/// Recibimos los datos del formulario de login y
		/// validamos que exista el usuario y coincida la contraseña.
		/// </summary>
		/// <param name="mail"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult DoLogin(string mail, string password)
		{
			//buscamos al usuario
			User user = db.User.FirstOrDefault(u => u.Email.Equals(mail));
			if (user != null
				&& user.Password.Equals(password)) //si existe (no queda null) y la contraseña coincide
			{
				Session["LoggedUser"] = user; //agregamos el objeto usuario a la sesión, para después tener control sobre él
				return RedirectToAction("Index", "Series");
			}
			//si no existe el usuario o lo contraseña no coincide
			return RedirectToAction("Login", "Users");
		}
	}
}
