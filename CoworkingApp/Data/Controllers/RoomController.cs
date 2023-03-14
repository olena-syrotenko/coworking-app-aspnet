using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

		[Route("Room/List")]
		[Route("Room/List/{roomType}")]
		public ViewResult List(string roomType)
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
				rooms = _rooms.getByRoomType(currType);
				currType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currType);
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
		public ViewResult Item(int roomId)
		{
			Room roomItem = _rooms.getById(roomId);
			if (roomItem == null)
            {
				return HttpNotFound();
			}
			ViewBag.Title = roomItem.name;
			return View(roomItem);
		}

        private ViewResult HttpNotFound()
        {
			ViewBag.Title = "Not found";
			ViewBag.Message = "No such rooms";
			return View("ErrorPage");
        }
    }
}