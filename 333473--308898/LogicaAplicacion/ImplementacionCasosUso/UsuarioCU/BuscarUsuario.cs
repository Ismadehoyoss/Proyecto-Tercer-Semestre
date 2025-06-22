using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class BuscarUsuario : IBuscarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }
        public BuscarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public ListadoUsuariosDTO Ejecutar(int id)
        {
            return UsuarioMapper.UsuarioToListadoUsuarioDTO(RepoUsuario.FindById(id));
        }
    }
}
