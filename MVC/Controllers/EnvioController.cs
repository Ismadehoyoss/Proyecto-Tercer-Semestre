
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filtro;
using MVC.Models.Agencias;
using MVC.Models.Envios;
using MVC.Models.Usuarios;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVC.Controllers
{
	public class EnvioController : Controller
	{
		

		
		// GET: Envio
		public ActionResult Index()
		{
			List<ListadoEnviosVM> listadoEnviosVMs = new List<ListadoEnviosVM>();
			try
			{
				HttpClient envio = new HttpClient();
				Task<HttpResponseMessage> tarea = envio.GetAsync("https://localhost:7286/api/Envio");
				tarea.Wait();
				HttpResponseMessage respuesta = tarea.Result;
				HttpContent contenido = respuesta.Content;
				Task<string> body = contenido.ReadAsStringAsync();
				body.Wait();
				string datos = body.Result;
				if (respuesta.IsSuccessStatusCode)
				{
					listadoEnviosVMs = JsonConvert.DeserializeObject<List<ListadoEnviosVM>>(datos);
				}
				else
				{ 
					ViewBag.Mensaje = datos;
				}
			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Datos incorrectos";
			}

			return View(listadoEnviosVMs);
		}

		// GET: Envio/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Envio/Create
		public ActionResult CreateEnvioComun()
		{
            AltaEnvioComunVM comunVM = new AltaEnvioComunVM();
			try
			{
			}
			catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

			return View(comunVM);
        }
		public ActionResult CreateEnvioUrgente()
		{
			AltaEnvioUrgenteVM urgenteVM = new AltaEnvioUrgenteVM();
			try
			{ 

			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Datos incorrectos";
			}

			return View(urgenteVM);
		}

		// POST: Envio/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateEnvioComun(AltaEnvioComunVM envioComun)
		{
			try { 
			

			}
			catch (Exception ex)
			{
				ViewBag.DatosExcepcion = ex.StackTrace;
				ViewBag.Mensaje = "Error en los datos";
			}
			return View(envioComun);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateEnvioUrgente(AltaEnvioUrgenteVM envioUrgente)
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				ViewBag.DatosExcepcion = ex.StackTrace;
				ViewBag.Mensaje = "Error en los datos";
			}
			return View(envioUrgente);
		}

		// GET: Envio/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Envio/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Envio/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Envio/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}	

		[HttpPost]
		public ActionResult CambiarEstadoFinalizado(string NroTracking)
		{
			Debug.WriteLine($"Valor recibido de NroTracking: '{NroTracking}'");
			try
			{
		
			}
			catch (Exception ex)
			{
				ViewBag.DatosExcepcion = ex.StackTrace;
				ViewBag.Mensaje = "Error en los datos";
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(Index));

		}

		public IActionResult AgregarSeguimiento(int envioId)
		{
			AgregarSeguimientoVM seguimientoVM = new AgregarSeguimientoVM();
			try
			{
				seguimientoVM.EnvioId = envioId;
				seguimientoVM.UsuarioId = (int)HttpContext.Session.GetInt32("usuarioId");
			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Datos incorrectos";
			}
			return View(seguimientoVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AgregarSeguimiento(AgregarSeguimientoVM seguimientoVM)
		{
			try
			{

			}
			catch (Exception ex)
			{
				ViewBag.DatosExcepcion = ex.StackTrace;
				ViewBag.Mensaje = "Error en los datos";
			}
			return View(seguimientoVM);
		}

		public ActionResult FindByNroTracking()
		{
			return View();
		}

		[HttpPost]
		public ActionResult FindByNroTracking(string nroTracking)
		{
			ListadoEnviosVM envioEncontrado = new ListadoEnviosVM();
			try
			{
				if (!string.IsNullOrEmpty(nroTracking))
				{
					HttpClient envio = new HttpClient();
					Task<HttpResponseMessage> tarea = envio.GetAsync($"https://localhost:7286/api/Envio/{nroTracking}");
					tarea.Wait();
					HttpResponseMessage respuesta = tarea.Result;
					HttpContent contenido = respuesta.Content;
					Task<string> body = contenido.ReadAsStringAsync();
					body.Wait();
					string datos = body.Result;
					if (respuesta.IsSuccessStatusCode)
					{
						envioEncontrado = JsonConvert.DeserializeObject<ListadoEnviosVM>(datos);
					}
					else
					{
						ViewBag.Mensaje = datos;
					}
				}
				else
				{
					ViewBag.Mensaje = "El número de tracking no puede estar vacío.";
				}
			}
			catch (Exception ex)
			{

				ViewBag.Mensaje = "Error";
			}
			return View(envioEncontrado);
		}

	}
}
