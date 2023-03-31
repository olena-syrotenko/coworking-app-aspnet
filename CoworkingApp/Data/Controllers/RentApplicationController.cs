using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CoworkingApp.Data.Controllers
{
    [Authorize]
    public class RentApplicationController : Controller
    {
        private readonly IRentApplication _rentApplications;

		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly RentCart _rentCart;
        public RentApplicationController(IRentApplication rentApplications, RentCart rentCart, IHttpContextAccessor httpContextAccessor)
        {
            _rentApplications = rentApplications;
            _rentCart = rentCart;
			_httpContextAccessor = httpContextAccessor;
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
				rentApplication.userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
				_rentApplications.createRentApplication(rentApplication);
                return RedirectToAction("Message", "Home", new { message = "Заявку на оренду відправлено на обробку!" });
            }
            return View(rentApplication);
        }

		[Route("RentApplication/List")]
		public ViewResult List()
		{
			IEnumerable<RentApplication> rentApplications = null;
			if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
			{
				rentApplications = _rentApplications.AllRentApplications.OrderByDescending(rp => rp.id);
			}
			else
			{
				var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
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

		[HttpPost]
		[Route("RentApplication/{applId}/update")]
		public IActionResult Update(int applId, string newStatus)
		{
			RentApplication rentApplication = _rentApplications.getById(applId);
			if (rentApplication == null)
			{
				return NotFound("No such rent application");
			}
			if (newStatus == null || newStatus.Length == 0)
			{
				return NotFound("No such status");
			}
			_rentApplications.updateRentApplication(rentApplication, newStatus);
			return RedirectToAction("List", "RentApplication");
		}
	}
}
