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
	public class AltaEnvioComun : IAltaEnvioComun
	{
		private IRepositorioEnvio RepoEnvio { get; set; }

		private IRepositorioUsuario RepoUsuario { get; set; }

		private IRepositorioAgencia RepoAgencia { get; set; }
		public AltaEnvioComun(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repoUsuario,IRepositorioAgencia repoAgencia)
		{
			RepoEnvio = repositorioEnvio;
			RepoUsuario = repoUsuario;
			RepoAgencia = repoAgencia;
		}

		public void Ejecutar(AltaEnvioComunDTO envioDTO)
		{
			if (envioDTO == null)
			{
				throw new ArgumentNullException("Datos Incorrectos");
			}
			Usuario usuario = RepoUsuario.FindById(envioDTO.FuncionarioId);
			Usuario cliente = RepoUsuario.FindById(envioDTO.ClienteId);
			Agencia agencia = RepoAgencia.FindById(envioDTO.AgenciaId);
			if (usuario != null && cliente != null)
			{
				Envio envio = EnvioMapper.ComunFromDTO(envioDTO,usuario, cliente, agencia);
				RepoEnvio.Add(envio);

			}
			else
			{
				throw new ArgumentException("El funcionario o el cliente no existen");
			}

		}
	}
}
