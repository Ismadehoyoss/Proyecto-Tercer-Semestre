using Compartido.DTOs.Envios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
	public interface IListadoEnvios
	{
		IEnumerable<ListadoEnviosDTO> Ejecutar();
	}
}
