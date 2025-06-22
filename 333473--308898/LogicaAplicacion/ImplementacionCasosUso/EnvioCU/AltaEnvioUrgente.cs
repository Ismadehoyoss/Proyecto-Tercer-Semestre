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
	public class AltaEnvioUrgente : IAltaEnvioUrgente
	{
		private IRepositorioEnvio RepoEnvio{ get; set; }

		private IRepositorioUsuario RepoUsuario { get; set; }
		public AltaEnvioUrgente(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repoUsuario)
		{
			RepoEnvio = repositorioEnvio;
			RepoUsuario = repoUsuario;
		}

		public void Ejecutar(AltaEnvioUrgenteDTO envioDTO)
		{
			if (envioDTO == null)
			{
				throw new ArgumentNullException("Datos Incorrectos");
			}
			Usuario usuario = RepoUsuario.FindById(envioDTO.FuncionarioId);
			Usuario cliente = RepoUsuario.FindById(envioDTO.ClienteId);
			if(usuario != null && cliente != null)
			{
				Envio envio = EnvioMapper.UrgenteFromDTO(envioDTO,usuario, cliente);
				RepoEnvio.Add(envio);
				
			}
			else
			{
				throw new ArgumentException("El funcionario o el cliente no existen");
			}
			
		}
	}
}

