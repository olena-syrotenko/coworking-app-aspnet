using System.Collections.Generic;

public interface IRoomType
{
    IEnumerable<RoomType> AllRoomTypes { get; }
}