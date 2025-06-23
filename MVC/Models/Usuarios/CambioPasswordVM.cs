namespace MVC.Models.Usuarios
{
    public class CambioPasswordVM
    {
        public string? Email { get; set; }
        public string PasswordActual { get; set; }
        public string PasswordNueva { get; set; }
    }
}
