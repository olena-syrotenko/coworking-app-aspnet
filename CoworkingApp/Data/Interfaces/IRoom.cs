using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IRoom
	{
		IEnumerable<Room> AllRooms { get; }
		IEnumerable<Room> PopularRooms { get; set; }
		Room getById(int id);
	}
}