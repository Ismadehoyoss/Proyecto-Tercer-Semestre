
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filtro;
using MVC.Models.Usuarios;


namespace MVC.Controllers
{
	//[Admin]
	public class UsuarioController : Controller
	{
		
		// GET: UsuarioController

		public ActionResult Index()
		{

		
			List<ListadoUsuariosViewModel> listadoUsuarioViewModel =
				new List<ListadoUsuariosViewModel>();
			try
			{

				
			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Datos incorrectos";
			}

			return View(listadoUsuarioViewModel);
		}

		// GET: UsuarioController/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: UsuarioController/Create

		[Admin]
		public ActionResult Create()
		{
			return View();
		}

		// POST: UsuarioController/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UsuarioViewModel usuarioVM)
		{
			try
			{
			
			}
			catch (Exception ex)
			{
				ViewBag.DatosExcepcion = ex.StackTrace;
				ViewBag.Mensaje = "Error en los datos";
			}
			return View();
		}

		// GET: UsuarioController/Edit/5

		public ActionResult Edit(int id)
		{
			ListadoUsuariosViewModel usuarioVM = null;
			try
			{
			}
			catch (Exception ex)
			{

				ViewBag.Mensaje = ex.Message;
			}

			return View(usuarioVM);		
		}
		// POST: UsuarioController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ListadoUsuariosViewModel usuarioVM)
		{
            try
            {
                
                
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View();
        }

		// GET: UsuarioController/Delete/5

		public ActionResult Delete(int id)
		{
            ListadoUsuariosViewModel usuarioVM = null;
            try
            { 
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View(usuarioVM);
        }

		// POST: UsuarioController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, ListadoUsuariosViewModel usuarioVM)
		{
            try
            {
               
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View();
        }
		public ActionResult Login()
		{
			return View();
		}

		// POST: Usuario/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(string email, string contraseña)
		{
			try
			{
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
			}
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}
	}
}
