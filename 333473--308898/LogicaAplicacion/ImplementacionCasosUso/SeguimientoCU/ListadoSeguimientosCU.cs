using Compartido.DTOs.Seguimiento;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.SeguimientoCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.SeguimientoCU
{
	public class ListadoSeguimientosCU : IListadoSeguimientos
	{
		private IRepositorioSeguimiento RepositorioSeguimiento { get; set; }
		public ListadoSeguimientosCU(IRepositorioSeguimiento repositorioSeguimiento)
		{
			RepositorioSeguimiento = repositorioSeguimiento;
		}
		public IEnumerable<SeguimientoDTO> Ejecutar(int envioId)
		{
			IEnumerable<SeguimientoDTO> seguimientosDTO = new List<SeguimientoDTO>();
			IEnumerable<Seguimiento> seguimientos = RepositorioSeguimiento.FindByEnvioId(envioId);
			seguimientosDTO = SeguimientoMapper.ListadoSeguimientoToListadoSeguimientoDTO(seguimientos);
			return seguimientosDTO;

		}
	}
}
