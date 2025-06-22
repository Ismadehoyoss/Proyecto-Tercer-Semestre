namespace MVC.Models.Usuarios
{
	public class ClienteViewModel
	{
		public int Id { get; set; }
		public string Ci { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Contraseña { get; set; }
		public Rol Rol { get; set; }
	}
}
