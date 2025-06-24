
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.SeguimientoCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaAplicacion.InterfacesCasosUso.SeguimientoCU;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
			builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();
			builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgenciaEF>();
			builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimientoEF>();
			builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
			//builder.Services.AddScoped<IRegistrarUsuario, RegistroUsuario>();
			builder.Services.AddScoped<IEliminarUsuario, EliminarUsuario>();
			builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
			builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
			builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
			builder.Services.AddScoped<IAltaEnvioUrgente, AltaEnvioUrgente>();
			builder.Services.AddScoped<IAltaEnvioComun, AltaEnvioComun>();
			builder.Services.AddScoped<IListadoEnvios, ListadoEnvios>();
			builder.Services.AddScoped<IFinalizarEnvio, FinalizarEnvio>();
			builder.Services.AddScoped<IListadoCliente, ListadoClientes>();
			builder.Services.AddScoped<IListadoAgencias, ListadoAgencia>();
			builder.Services.AddScoped<IAgregarSeguimiento, AgregarSeguimiento>();
			builder.Services.AddScoped<IBuscarEnvios, BuscarEnvios>();
			builder.Services.AddScoped<IModificarPassword, ModificarPassword>();
			builder.Services.AddScoped<IListadoEnviosClienteLogueado, ListadoEnviosClienteLogueado>();
			builder.Services.AddScoped<IListadoSeguimientos, ListadoSeguimientosCU>();
			
			string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
			builder.Services.AddDbContext<DemoContext>(option => option.UseSqlServer(cadenaConexion));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddControllersWithViews();
			builder.Services.AddSession();
			var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

			builder.Services.AddAuthentication(aut =>
			{
				aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(aut =>
			{
				aut.RequireHttpsMetadata = false;
				aut.SaveToken = true;
				aut.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
