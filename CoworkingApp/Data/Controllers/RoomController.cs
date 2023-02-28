using CoworkingApp.Data.Interfaces;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoworkingApp.Data.Controllers
{
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
            ViewBag.Title = "Сторінка з кімнатами";
            RoomListViewModels roomListViewModels = new RoomListViewModels();
            roomListViewModels.allRooms = _rooms.AllRooms;
            roomListViewModels.currentType = "Кімнати";
            return View(roomListViewModels);
        }
    }
}