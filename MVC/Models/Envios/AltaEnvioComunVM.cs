
using MVC.Models.Usuarios;
using MVC.Models.Agencias;

namespace MVC.Models.Envios
{
	public class AltaEnvioComunVM
	{
		public string NumeroTracking { get; set; }
		public int Peso { get; set; }
		public int FuncionarioId { get; set; }
		public int ClienteId { get; set; }
		public int AgenciaId { get; set; }

		public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
			= new List<UsuarioViewModel>();

			public IEnumerable<ClienteViewModel> Cliente { get; set; } 
			= new List<ClienteViewModel>();
		public IEnumerable<AgenciaViewModel> Agencia { get; set; }
			= new List<AgenciaViewModel>();
	}
}
