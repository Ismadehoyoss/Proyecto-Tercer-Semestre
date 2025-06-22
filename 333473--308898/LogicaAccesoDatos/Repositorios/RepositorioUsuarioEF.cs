using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaAccesoDatos.Repositorios
{
	public class RepositorioUsuarioEF : IRepositorioUsuario
	{
		private DemoContext Contexto { get; set; }

		public RepositorioUsuarioEF(DemoContext contexto)
		{
			Contexto = contexto;
		}
		public void Add(Usuario item)
		{
			Usuario usuarioEncontrado = FindByCi(item.Ci.Valor);
			if (usuarioEncontrado == null)
			{
				Contexto.Usuarios.Add(item);
				Contexto.SaveChanges();
			}
			else
			{
				throw new UsuarioException("Ya existe un usuario con esa Cedula");
			}
		}
	

		public void Delete(int id)
		{
			Usuario usuarioBuscado = FindById(id);
			if (usuarioBuscado != null)
			{
				Contexto.Usuarios.Remove(usuarioBuscado);
				Contexto.SaveChanges();
			}
			else
			{
				throw new UsuarioException("No existe un Usuario con esa Cedula");
			}
		}
        public IEnumerable<Usuario> FindAll()
        {
			return Contexto.Usuarios;
                
            
            
        }
		public void Update(Usuario item)
		{
			
			Usuario usuarioBuscado = FindByCi(item.Ci.Valor);

			
			if (usuarioBuscado != null || usuarioBuscado == null && usuarioBuscado.Ci == item.Ci )
			{
				usuarioBuscado.Nombre = item.Nombre;
				usuarioBuscado.Apellido = item.Apellido;
				usuarioBuscado.Email = item.Email;
				usuarioBuscado.Contraseña = item.Contraseña;
				usuarioBuscado.Rol = item.Rol;
                Contexto.SaveChanges();
            }

			
			
		}
		public Usuario FindById(int id)
		{
			return Contexto.Usuarios.Find(id);
		}

		private Usuario FindByCi(string cedulaUsuario)
		{
			return Contexto.Usuarios.Where(c => c.Ci.Valor == cedulaUsuario).SingleOrDefault();
		}

		private Usuario FindByEmail(string email)
		{
			return Contexto.Usuarios.Where(c => c.Email == email).SingleOrDefault();
		}

		Usuario IRepositorioUsuario.FindByEmail(string email)
		{
			return FindByEmail(email);
		}
		public IEnumerable<Usuario> FindByRolFuncionario()
		{
			return Contexto.Usuarios.Where(c =>c.Rol == Rol.Funcionario|| c.Rol == Rol.Administrador).ToList();
		}
		public IEnumerable<Usuario> FindByRolCliente()
		{
			return Contexto.Usuarios.Where(c => c.Rol == Rol.Cliente).ToList();

		}
	}
}
