using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infra.Mappings;

namespace Project.Infra.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> builder)
			: base(builder)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new LancamentosMap());
			modelBuilder.ApplyConfiguration(new ControleEncargosMap());
			

		}

		public DbSet<ControleEncargos> ControleEncargos { get; set; }
		public DbSet<Lancamentos> Lancamentos { get; set; }
	}
}
