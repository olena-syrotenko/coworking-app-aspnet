using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IRoomType
	{
		IEnumerable<RoomType> AllRoomTypes { get; }
	}
}