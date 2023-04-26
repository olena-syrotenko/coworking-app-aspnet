using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Utils;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoworkingApp.Data.Controllers
{
	[AllowAnonymous]
	public class RoomController : Controller
	{
		private readonly IRoom _rooms;
		private readonly IRoomType _roomTypes;

		public RoomController(IRoom rooms, IRoomType roomTypes)
		{
			_rooms = rooms;
			_roomTypes = roomTypes;
		}

		[Route("Room/List")]
		[Route("Room/List/{roomType}")]
		public ViewResult List(string roomType, string sortType = "")
		{
			IEnumerable<Room> rooms = null;
			string currType = "";
			if (string.IsNullOrEmpty(roomType))
			{
				rooms = _rooms.AllRooms.OrderBy(i => i.id);
				currType = "Усі кімнати";
			}
			else
			{
				currType = roomType.Replace('-', ' ').ToLower();
				rooms = _rooms.getByRoomType(currType).OrderBy(i => i.id);
				currType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currType);
			}

			if (sortType.ToLower().Equals(Constants.ASC))
            {
				rooms = rooms.OrderBy(r => r.price);
            } 
			else if (sortType.ToLower().Equals(Constants.DESC))
            {
				rooms = rooms.OrderByDescending(r => r.price);
			}

			RoomListViewModels roomListViewModels = new RoomListViewModels()
			{
				currentType = currType,
				allRooms = rooms,
			};
			ViewBag.Title = "Сторінка з кімнатами";
			return View(roomListViewModels);
		}

		[Route("Room/Item/{roomId}")]
		public IActionResult Item(int roomId)
		{
			Room roomItem = _rooms.getById(roomId);
			if (roomItem == null)
            {
				return NotFound("No such rooms");
			}
			ViewBag.Title = roomItem.name;
			return View(roomItem);
		}
    }
}