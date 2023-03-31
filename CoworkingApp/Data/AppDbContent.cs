using CoworkingApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoworkingApp.Data
{
	public class AppDbContent : IdentityDbContext<User>
	{
		public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }

		public DbSet<Room> Room { get; set; }

		public DbSet<RoomType> RoomType { get; set; }
		
		public DbSet<Place> Place { get; set; }

		public DbSet<Service> Service { get; set; }

		public DbSet<RentCartItem> RentCartItem { get; set; }

		public DbSet<RentApplication> RentApplication { get; set; }
		
		public DbSet<RentApplicationDetail> RentApplicationDetail { get; set; }
		
		public DbSet<Status> Status { get; set; }

	}
}