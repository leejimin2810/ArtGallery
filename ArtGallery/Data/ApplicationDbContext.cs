using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Artist> Artists { get; set; }
		public DbSet<Artwork> Artworks { get; set; }
		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Exhibition> Exhibitions { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
	}
}



