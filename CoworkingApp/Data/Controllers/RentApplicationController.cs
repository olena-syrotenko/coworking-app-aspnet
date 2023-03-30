using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return RedirectToAction("Message", "Home", new { message = "Заявку на оренду відправлено на обробку!" });
            }
            return View(rentApplication);
        }
    }
}