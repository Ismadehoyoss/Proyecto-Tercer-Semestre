namespace MVC.Models.Usuarios
{
	public class UsuarioLogueadoVM
	{
		public string Token { get; set; }

		public string Email { get; set; }

		public Rol Rol { get; set; }

		public int Id { get; set; }
	}
}
