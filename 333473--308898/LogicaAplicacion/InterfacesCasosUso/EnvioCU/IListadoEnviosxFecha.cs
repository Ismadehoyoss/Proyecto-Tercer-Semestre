using Compartido.DTOs.Envios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
	public interface IListadoEnviosxFecha
	{
		IEnumerable<ListadoEnviosDTO> Ejecutar(DateTime fechaInicio, DateTime fechaFin, int clienteId);

	}
}
