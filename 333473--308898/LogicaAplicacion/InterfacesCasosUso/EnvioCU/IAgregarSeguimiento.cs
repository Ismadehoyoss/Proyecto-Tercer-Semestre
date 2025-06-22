using Compartido.DTOs.Seguimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
	public interface IAgregarSeguimiento
	{
		void Ejecutar(SeguimientoDTO seguimientoDTO);
	}
}
