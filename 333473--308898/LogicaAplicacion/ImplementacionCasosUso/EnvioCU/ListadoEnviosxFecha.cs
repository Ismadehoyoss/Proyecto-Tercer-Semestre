using Compartido.DTOs.Envios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
	public class ListadoEnviosxFecha : IListadoEnviosxFecha
	{
		private IRepositorioEnvio RepoEnvio { get; set; }
		public ListadoEnviosxFecha(IRepositorioEnvio repositorioEnvio)
		{
			RepoEnvio = repositorioEnvio;
		}
		public IEnumerable<ListadoEnviosDTO> Ejecutar(DateTime fechaInicio, DateTime fechaFin , int clienteId, Estado? estado)
		{
			
			IEnumerable<ListadoEnviosDTO> listadoEnviosDTO = new List<ListadoEnviosDTO>();
			IEnumerable<Envio> envios = RepoEnvio.FindByFechas(fechaInicio, fechaFin, clienteId, estado);
			listadoEnviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
			return listadoEnviosDTO;
		}

	}
}
