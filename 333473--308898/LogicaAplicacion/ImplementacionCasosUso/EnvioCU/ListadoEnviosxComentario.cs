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
	public class ListadoEnviosxComentario : IListadoEnviosxComentario
	{
		private IRepositorioEnvio RepoEnvio { get; set; }
		public ListadoEnviosxComentario(IRepositorioEnvio repoEnvio)
		{
			RepoEnvio = repoEnvio;
		}
		public IEnumerable<ListadoEnviosDTO> Ejecutar(string comentario, int clienteId)
		{
	
			IEnumerable<ListadoEnviosDTO> listadoEnviosDTO = new List<ListadoEnviosDTO>();
			IEnumerable<Envio> envios = RepoEnvio.FindByComentario(comentario, clienteId);
			listadoEnviosDTO = EnvioMapper.ListadoEnvioToListadoEnvioDTO(envios);
			return listadoEnviosDTO;


		}
	}
}
