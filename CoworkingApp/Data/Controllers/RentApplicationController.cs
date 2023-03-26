using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CoworkingApp.Data.Controllers
{
    public class RentApplicationController : Controller
    {
        private readonly IRentApplication _rentApplications;
        private readonly RentCart _rentCart;
        public RentApplicationController(IRentApplication rentApplications, RentCart rentCart)
        {
            _rentApplications = rentApplications;
            _rentCart = rentCart;
        }

        [Route("Rent/{roomId}")]
        public IActionResult Rent(int roomId)
        {
            return View();
        }

        [HttpPost]
        [Route("Rent/{roomId}")]
        public IActionResult Rent(PlaceDto placeDto, int roomId)
        {
            if(!ModelState.IsValid)
            {
                return View(placeDto);
            }

            Place availablePlace = _rentApplications.getAvailablePlaceInRoom(placeDto.rentStart, placeDto.rentEnd, roomId);

            if (availablePlace != null)
            {
                placeDto.place = availablePlace;
                placeDto.placeId = availablePlace.id;
                return View(placeDto);
            }

            return RedirectToAction("Complete", new { message = "На жаль, на обрані дати немає вільних місць :(" });
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(RentApplication rentApplication)
        {
            _rentCart.rentCartItems = _rentCart.getRentItems();
            if (_rentCart.rentCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Ви повинні додати робочі місця!");
            }
            if (ModelState.IsValid)
            {
                _rentApplications.createRentApplication(rentApplication);
                return RedirectToAction("Complete", new { message = "Заявку на оренду відправлено на обробку!" });
            }
            return View(rentApplication);
        }

        public IActionResult Complete(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}