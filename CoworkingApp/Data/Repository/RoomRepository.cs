using CoworkingApp.Data;
using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Repository
{
	public class RoomRepository : IRoom
	{
		private readonly AppDbContent appDbContent;

		public RoomRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public IEnumerable<Room> AllRooms => appDbContent.Room.Include(r => r.roomType);

		public IEnumerable<Room> PopularRooms { get => throw new System.NotImplementedException(); }

		public Room getById(int id) => appDbContent.Room.FirstOrDefault(r => r.id == id);
	}
}