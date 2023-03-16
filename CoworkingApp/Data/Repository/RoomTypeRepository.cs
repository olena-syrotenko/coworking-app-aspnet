using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Repository
{
	public class RoomTypeRepository : IRoomType
	{
		private readonly AppDbContent appDbContent;

		public RoomTypeRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public IEnumerable<RoomType> AllRoomTypes => appDbContent.RoomType;
	}
}