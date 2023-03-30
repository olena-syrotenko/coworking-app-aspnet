using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Data.Controllers
{
    [Authorize]
    public class RentApplicationController : Controller
    {
        private readonly IRentApplication _rentApplications;
        private readonly RentCart _rentCart;
        public RentApplicationController(IRentApplication rentApplications, RentCart rentCart)
        {
            _rentApplications = rentApplications;
            _rentCart = rentCart;
        }

		[Route("RentApplication/Checkout")]
		public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
		[Route("RentApplication/Checkout")]
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
                return RedirectToAction("Message", "Home", new { message = "Заявку на оренду відправлено на обробку!" });
            }
            return View(rentApplication);
        }

		[Route("RentApplication/List")]
		[Route("RentApplication/List/{userId}")]
		public ViewResult List(string userId)
		{
			IEnumerable<RentApplication> rentApplications = null;
			if (string.IsNullOrEmpty(userId))
			{
				rentApplications = _rentApplications.AllRentApplications.OrderByDescending(rp => rp.id);
			}
			else
			{
				rentApplications = _rentApplications.getByUserId(userId).OrderByDescending(rp => rp.id);
			}

			RentApplicationViewModel rentApplicationViewModel = new RentApplicationViewModel()
			{
				rentApplications = rentApplications
			};
			ViewBag.Title = "Заявки на оренду";
			return View(rentApplicationViewModel);
		}

		[Route("RentApplication/{applId}")]
		public IActionResult Item(int applId)
		{
			RentApplication rentApplication = _rentApplications.getById(applId);
			if (rentApplication == null)
			{
				return NotFound("No such rent application");
			}
			ViewBag.Title = "Заявка №" + rentApplication.id;
			return View(rentApplication);
		}
	}
}
