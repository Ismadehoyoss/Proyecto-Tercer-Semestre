
using MVC.Models.Usuarios;

namespace MVC.Models.Envios
{
	public class AltaEnvioUrgenteVM
	{
		public string NumeroTracking { get; set; }
		public int Peso { get; set; }
		public int FuncionarioId { get; set; }
		public int ClienteId { get; set; }
		public string DireccionPostal { get; set; }
		public bool Entregado { get; set; }
		public int TiempoEntrega { get; set; }

		public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
			 = new List<UsuarioViewModel>();

		public IEnumerable<ClienteViewModel> Cliente { get; set; }
		= new List<ClienteViewModel>();
	}
}
