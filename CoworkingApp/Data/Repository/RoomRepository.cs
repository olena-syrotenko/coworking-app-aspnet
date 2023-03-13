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

		public IEnumerable<Room> AllRooms => appDbContent.Room.Include(r => r.roomType).Include(r => r.services);

        public IEnumerable<Room> FavouriteRooms => appDbContent.Room.Where(r => r.isFavourite).Include(r => r.roomType).Include(r => r.services);

        public Room getById(int id) => appDbContent.Room.FirstOrDefault(r => r.id == id);
	}
}