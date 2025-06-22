using Compartido.DTOs.Agencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.AgenciaCU
{
	public interface IListadoAgencias
	{
		IEnumerable<ListadoAgenciasDTO> Ejecutar();
	}
}
