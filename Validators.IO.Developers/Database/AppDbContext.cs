using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validators.IO.Developers.Database.Entities;

namespace Validators.IO.Developers.Database
{
	public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{
		}

		public IQueryable<Project> ActiveProjects { get { return Projects.Where(p => p.IsDeleted == false); } }

		public DbSet<Project> Projects { get; set; }

		public DbSet<Blockchain> Blockchains { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlite("Data Source=database.db");
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Admin role
			//
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });


			// Default Blockchain (Validators)
			//
			modelBuilder.Entity<Blockchain>().HasData(new Blockchain
			{
				Id = 1,
				Name = "Polkadot",
				Currency = "DOT"
			});

			base.OnModelCreating(modelBuilder);
		}

	}

}
