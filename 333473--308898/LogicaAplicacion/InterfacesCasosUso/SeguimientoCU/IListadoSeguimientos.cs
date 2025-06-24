using Compartido.DTOs.Seguimiento;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.SeguimientoCU
{
	public interface IListadoSeguimientos
	{
		IEnumerable<SeguimientoDTO> Ejecutar(int envioId);
	}
}
