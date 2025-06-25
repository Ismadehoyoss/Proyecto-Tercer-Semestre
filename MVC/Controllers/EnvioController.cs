
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
		private string urlBase = "";

		public EnvioController(IConfiguration configuration)
		{
			urlBase = configuration.GetValue<string>("UrlBase");
		}


		// GET: Envio
		public ActionResult Index()
		{
			string rol = HttpContext.Session.GetString("Rol");
			if (rol == "Cliente")
			{
				return RedirectToAction("MisEnvios", "Envio");
			}
			List<ListadoEnviosVM> listadoEnviosVMs = new List<ListadoEnviosVM>();
			try
			{
				HttpClient client = new HttpClient();
				Task<HttpResponseMessage> tarea = client.GetAsync(urlBase+ "/Envio");
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


		public ActionResult MisEnvios()
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Cliente")
			{
				
				return RedirectToAction("Index", "Envio"); 
			}
			List<ListadoEnviosVM> listadoEnviosVMs = new List<ListadoEnviosVM>();
			try
			{
				int usuarioId = (int)HttpContext.Session.GetInt32("Id");
				HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
				Task<HttpResponseMessage> tarea = client.GetAsync(urlBase + "/Envio/cliente/" + usuarioId);
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
		public ActionResult EnviosxFecha(DateTime fechaInicio, DateTime fechaFin)
		{

			List<ListadoEnviosVM> listadoEnviosVMs = new List<ListadoEnviosVM>();
			if (fechaInicio == DateTime.MinValue || fechaFin == DateTime.MinValue)
			{
				ViewBag.Mensaje = "Debe ingresar ambas fechas para filtrar.";
				return View(new List<ListadoEnviosVM>());
			}
			try
			{
				int clienteId = (int)HttpContext.Session.GetInt32("Id");
				if (clienteId == 0)
				{
					ViewBag.Mensaje = "Cliente no identificado.";
					return View(listadoEnviosVMs);
				}
				HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
				Task<HttpResponseMessage> tarea = client.GetAsync(urlBase + $"/envio/porFechas?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}&clienteId={clienteId}");
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
				ViewBag.Mensaje = "Datos Incorrectos";
			}
			return View(listadoEnviosVMs);
		}

		public ActionResult Seguimientos(int envioId)
		{
			List<ListadoSeguimientosVM> listadoSeguimientosVM = new List<ListadoSeguimientosVM>();
			try
			{
				HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
				Task<HttpResponseMessage> tarea = client.GetAsync(urlBase + "/seguimiento/envio/" + envioId);
				tarea.Wait();
				HttpResponseMessage respuesta = tarea.Result;
				HttpContent contenido = respuesta.Content;
				Task<string> body = contenido.ReadAsStringAsync();
				body.Wait();
				string datos = body.Result;
				if (respuesta.IsSuccessStatusCode)
				{
					listadoSeguimientosVM = JsonConvert.DeserializeObject<List<ListadoSeguimientosVM>>(datos);
				}
				else
				{
					ViewBag.Mensaje = datos;
				}
			}
			catch (Exception ex)
			{
				ViewBag.Mensaje = "Datos Incorrectos";
				
			}
			return View(listadoSeguimientosVM);
		}

		// GET: Envio/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Envio/Create
		public ActionResult CreateEnvioComun()
		{
			AltaEnvioComunVM model = new AltaEnvioComunVM
			{
				Usuarios = new List<UsuarioViewModel>(),
				Cliente = new List<ClienteViewModel>()
			};
			return View(model);
		}
		public ActionResult CreateEnvioUrgente()
		{
			AltaEnvioUrgenteVM model = new AltaEnvioUrgenteVM
			{
				Usuarios = new List<UsuarioViewModel>(),  
				Cliente = new List<ClienteViewModel>()    
			};
			return View(model);
		}

		// POST: Envio/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateEnvioComun(AltaEnvioComunVM envioComun)
		{
			try
			{
				if (ModelState.IsValid)
				{
					HttpClient cliente = new HttpClient();
					Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(urlBase + "/envio/comun", envioComun);
					tarea.Wait();
					HttpResponseMessage respuesta = tarea.Result;
					if (respuesta.IsSuccessStatusCode)
					{
						return RedirectToAction(nameof(Index));
					}
					else
					{
						HttpContent contenido = respuesta.Content;
						Task<string> body = contenido.ReadAsStringAsync();
						body.Wait();
						ViewBag.Mensaje = body.Result;
					}
				}
				else
				{
					ViewBag.Mensaje = "Datos incorrectos, por favor verifique los campos ingresados.";
				}
			}
			catch (Exception ex)
			{
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
				if (ModelState.IsValid)
				{
					HttpClient cliente = new HttpClient();
					Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(urlBase +"/envio/urgente", envioUrgente);
					tarea.Wait();
					HttpResponseMessage respuesta = tarea.Result;
					if (respuesta.IsSuccessStatusCode)
					{
						return RedirectToAction(nameof(Index));
					}
					else
					{
						HttpContent contenido = respuesta.Content;
						Task<string> body = contenido.ReadAsStringAsync();
						body.Wait();
						ViewBag.Mensaje = body.Result;
					}
				}
				else
				{
					ViewBag.Mensaje = "Datos incorrectos, por favor verifique los campos ingresados.";
				}
			}
			catch (Exception ex)
			{
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
					Task<HttpResponseMessage> tarea = envio.GetAsync(urlBase+"/FindByNroTracking/" + nroTracking);
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
