namespace MVC.Models.Envios
{
	public class AgregarSeguimientoVM
	{
		public string Comentario { get; set; }
		public DateTime FechaHora { get; set; }
		public int EnvioId { get; set; }
		public int UsuarioId { get; set; }
	}
}
