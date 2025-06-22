using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaNegocio.ValueObject
{
	[ComplexType]
	public class CedulaUsuario
	{
		public string Valor { get; init; }

		public CedulaUsuario(string valor)
		{
			Valor = valor;
			Validar();
		}

		private void Validar()
		{
			if (string.IsNullOrEmpty(Valor))
			{
				throw new UsuarioException("La Cedula es obligatoria");
			}
			if (Valor.Length < 8)
			{
				throw new UsuarioException("La cedula debe ser de 8 digitos");
			}
			if (Valor.Length > 8)
			{
				throw new UsuarioException("La cedula debe ser de 8 digitos");
			}
		}
	}
}
