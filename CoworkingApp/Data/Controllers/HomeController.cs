using CoworkingApp.Data.Interfaces;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoworkingApp.Data.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRoom _roomRepository;

		public HomeController(IRoom roomRepository)
		{
			_roomRepository = roomRepository;
		}

		[Route("")]
		public ViewResult Index()
		{
			var homeRooms = new HomeViewModel
			{
				favouriteRooms = _roomRepository.FavouriteRooms
			};
			return View(homeRooms);
		}
		
	}
}