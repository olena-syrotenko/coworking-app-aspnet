using System.Collections.Generic;

public interface IRoom
{
    IEnumerable<Room> AllRooms { get; }
    IEnumerable<Room> PopularRooms { get; set; }
    Room getById(int id);
}