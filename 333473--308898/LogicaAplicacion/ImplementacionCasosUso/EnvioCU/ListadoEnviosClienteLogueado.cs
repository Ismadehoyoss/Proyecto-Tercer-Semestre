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
	public class ListadoEnviosClienteLogueado :IListadoEnviosClienteLogueado
	{
		private IRepositorioEnvio RepoEnvio { get; set; }
		public ListadoEnviosClienteLogueado(IRepositorioEnvio repoenvio)
		{
			RepoEnvio = repoenvio;
		}
		public IEnumerable<ListadoEnviosDTO> Ejecutar(int clienteId)
		{
			IEnumerable<ListadoEnviosDTO> enviosDTO = new List<ListadoEnviosDTO>();
			IEnumerable<Envio> envios = RepoEnvio.FindByCliente(clienteId);
			enviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
			return enviosDTO;

		}
	}
}
