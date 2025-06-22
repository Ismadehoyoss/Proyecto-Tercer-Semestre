using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Usuario : IEquatable<Usuario>
	{

		public int Id { get; set; }
		public CedulaUsuario Ci { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Contraseña { get; set; }
		public Rol Rol { get; set; }

		private Usuario() { }

		public Usuario(string ci, string nombre, string apellido, string email, string contraseña, Rol rol)
		{
			Ci = new CedulaUsuario(ci);
			Nombre = nombre;
			Apellido = apellido;
			Email = email;
			Contraseña = contraseña;
			Rol = rol;
		}

		public bool Equals(Usuario? other)
		{
			return Ci == other.Ci;
		}
	}
	public enum Rol
	{
		Administrador,
		Funcionario,
		Cliente ,
	}
}
