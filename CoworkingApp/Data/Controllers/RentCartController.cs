using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Models.Dto;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoworkingApp.Data.Controllers
{
    public class RentCartController : Controller
    {
        private readonly IPlace _placeRepository;
        private readonly RentCart _rentCart;

        public RentCartController(IPlace placeRepository, RentCart rentCart)
        {
            _placeRepository = placeRepository;
            _rentCart = rentCart;
        }

        public ViewResult Index()
        {
            var items = _rentCart.getRentItems();
            _rentCart.rentCartItems = items;
            var rentCartViewModel = new RentCartViewModel
            {
                rentCart = _rentCart
            };
            return View(rentCartViewModel);
        }
        public RedirectToActionResult AddToCart(PlaceDto placeDto)
        {
            var item = _placeRepository.AllPlaces.FirstOrDefault(i => i.id == placeDto.placeId);
            if (item != null)
            {
                placeDto.place = item;
                _rentCart.AddToCart(placeDto);
            }
            return RedirectToAction("Index");
        }

    }
}