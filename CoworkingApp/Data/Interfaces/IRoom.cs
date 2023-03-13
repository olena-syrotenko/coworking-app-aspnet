using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IRoom
	{
		IEnumerable<Room> AllRooms { get; }
		Room getById(int id);
	}
}