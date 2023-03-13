using CoworkingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoworkingApp.Data
{
	public class AppDbContent : DbContext
	{
		public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }

		public DbSet<Room> Room { get; set; }

		public DbSet<RoomType> RoomType { get; set; }
		
		public DbSet<Place> Place { get; set; }

		public DbSet<Service> Service { get; set; }

		public DbSet<RentCartItem> RentCartItem { get; set; }

	}
}