using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
   public class ModificarUsuario : IModificarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public ModificarUsuario(IRepositorioUsuario repousuario)
        {
            RepoUsuario = repousuario;
        }

        public void Ejecutar(ListadoUsuariosDTO usuariosDTO)
        {
            Usuario usuario = UsuarioMapper.UsuarioFromListadoUsuarioDTO(usuariosDTO);
            usuario.Id = usuariosDTO.Id;
            RepoUsuario.Update(usuario);
        }
    }
}
