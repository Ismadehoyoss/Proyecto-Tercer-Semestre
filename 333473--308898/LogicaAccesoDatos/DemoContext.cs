using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
	public class DemoContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }

		public DbSet<Envio> Envios { get; set; }

		public DbSet<Urgente>Urgente { get; set; }

		public DbSet<Comun> Comun { get; set; }

		public DbSet<Agencia> Agencias { get; set; }

		public DbSet<Seguimiento> Seguimientos { get; set; }



		public DemoContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			

			modelBuilder.Entity<Envio>().HasOne(e => e.Funcionario)
				.WithMany()
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Envio>().HasOne(e => e.Cliente)
				.WithMany()
				.OnDelete(DeleteBehavior.NoAction);

			base.OnModelCreating(modelBuilder);
		}
	}
}
