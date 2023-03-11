using CoworkingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoworkingApp.Data
{
	public class AppDbContent : DbContext
	{
		public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }

		public DbSet<Room> Room { get; set; }

		public DbSet<RoomType> RoomType { get; set; }

	}
}