using System.Web.Mvc;

public class RoomController : Controller
{
    private readonly IRoom _rooms;
    private readonly IRoomType _roomTypes;

    public RoomController(IRoom rooms, IRoomType roomTypes)
    {
        _rooms = rooms;
        _roomTypes = roomTypes;
    }
    public ViewResult List()
    {
        var rooms = _rooms.AllRooms;
        return View(rooms);
    }
}
