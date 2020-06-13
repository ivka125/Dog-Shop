using ItCareer.Models;
using Microsoft.EntityFrameworkCore;

namespace ItCareer.Database
{
	public class DogContext : DbContext 
	{
		public DbSet<Dog> Dogs { get; set; }
		
		public DbSet<Breed> Breeds { get; set; }

		public DbSet<Colour> Colours { get; set; }
		
		public DogContext(DbContextOptions options)
		: base (options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Dog>()
				.HasKey(x => x.Id);
		}
	}
}