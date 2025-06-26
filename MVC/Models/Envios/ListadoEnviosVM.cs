

namespace MVC.Models.Envios
{
	public class ListadoEnviosVM
	{
		public int Id { get; set; }
		public int Peso { get; set; }
		public string NroTracking { get; set; }
		public string FuncionarioNombre { get; set; }
		public string ClienteNombre { get; set; }
		public Estado Estado { get; set; }
		public DateTime FechaEstimada { get; set; }
		public DateTime FechaEntrega { get; set; }
		public List<ListadoSeguimientosVM> Seguimientos { get; set; }

		
	}
	public enum Estado
	{
		En_Proceso,
		Finalizado
	}
}
