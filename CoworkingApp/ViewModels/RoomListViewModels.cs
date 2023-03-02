using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.ViewModels
{
	public class RoomListViewModels
	{
		public IEnumerable<Room> allRooms { get; set; }
		public string currentType { get; set; }
	}
}