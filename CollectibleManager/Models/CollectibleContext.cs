using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CollectibleManager.Models
{
	public class CollectibleContext : DbContext
	{
		public DbSet<Collectible> Collectibles { get; set; }
		public DbSet<CollectibleImage> Images { get; set; }
		public DbSet<CollectibleManufacturer> Manufacturers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}