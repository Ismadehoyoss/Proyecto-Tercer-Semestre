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
	public class ListadoEnvios : IListadoEnvios
	{
		private IRepositorioEnvio RepoEnvio { get; set; }

		public ListadoEnvios(IRepositorioEnvio repoEnvio)
		{
			RepoEnvio = repoEnvio;
		}

		public IEnumerable<ListadoEnviosDTO> Ejecutar()
		{

			IEnumerable<ListadoEnviosDTO> enviosDTO = new List<ListadoEnviosDTO>();
			IEnumerable<Envio> envios = RepoEnvio.FindAll();
			enviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
			return enviosDTO;

		}
	}
}
