
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filtro;
using MVC.Models.Usuarios;
using Newtonsoft.Json;


namespace MVC.Controllers
{
	//[Admin]
	public class UsuarioController : Controller
	{
		private string urlBase = "";
		public UsuarioController(IConfiguration configuration)
		{
			urlBase = configuration.GetValue<string>("UrlBase") + "/Usuario";
		}
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
				if (ModelState.IsValid) 
				{
				
				}
				
			}
			catch (Exception ex)
			{
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
		public IActionResult Login()
		{
			return View();
		}
		
		// POST: Usuario/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(LoginViewModel usuarioLoginVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					HttpClient client = new HttpClient();
					Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(urlBase, usuarioLoginVM);
					tarea.Wait();
					HttpResponseMessage respuesta = tarea.Result;
					HttpContent contenido = respuesta.Content;
					Task<string> body = contenido.ReadAsStringAsync();
					body.Wait();
					string datos = body.Result;
					if (respuesta.IsSuccessStatusCode)
					{
						UsuarioLogueadoVM usuario = JsonConvert.DeserializeObject<UsuarioLogueadoVM>(datos);
						HttpContext.Session.SetString("Token", usuario.Token);
						HttpContext.Session.SetString("Rol", usuario.Rol.ToString());
						HttpContext.Session.SetString("Email", usuario.Email);
						HttpContext.Session.SetInt32("Id", usuario.Id);
						if (usuario.Rol.ToString() == "Administrador" || usuario.Rol.ToString() == "Funcionario")
						{
							return RedirectToAction("Index", "Envio");
						}
						else if (usuario.Rol.ToString() == "Cliente")
						{
							return RedirectToAction("MisEnvios", "Envio");
						}
							

					}
					else
					{
						ViewBag.Mensaje = datos;
					}
				}
				else
				{
					ViewBag.Mensaje = "Datos incorrectos";
				}
			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Error en los datos";
			}
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login" , "Usuario");
		}
        
        public IActionResult CambioPassword()
		{
			return View();
		}
        // Replacing the incorrect attribute usage
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CambioPassword(CambioPasswordVM passwordVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    passwordVM.Email = HttpContext.Session.GetString("Email");
                    HttpClient client = new HttpClient();
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                    Task <HttpResponseMessage> tarea = client.PutAsJsonAsync(urlBase, passwordVM);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = datos;
                        return RedirectToAction("Index", "Envio");
                    }
                    else
                    {
                        ViewBag.Mensaje = datos;
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Datos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los Datos";
            }
            return View();
        }


	}
}
