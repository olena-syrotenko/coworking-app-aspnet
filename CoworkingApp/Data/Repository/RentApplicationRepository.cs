using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Utils;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CoworkingApp.Data.Repository
{
    public class RentApplicationRepository : IRentApplication
    {
        private readonly RentCart rentCart;
        private readonly AppDbContent appDbContent;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RentApplicationRepository(AppDbContent appDbContent, RentCart rentCart, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContent = appDbContent;
            this.rentCart = rentCart;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void createRentApplication(RentApplication rentApplication)
        {
            rentApplication.createTime = DateTime.Now;
            rentApplication.totalPrice = rentCart.getRentItems().Sum(item => CalculationUtil.getTotalForPlace(item.place, item.rentStart, item.rentEnd));
            rentApplication.userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            appDbContent.RentApplication.Add(rentApplication);
            appDbContent.SaveChanges();

            appDbContent.RentApplicationDetail.AddRange(rentCart.rentCartItems
                .Select(item => new RentApplicationDetail
                {
                    rentApplicationId = rentApplication.id,
                    placeId = item.id,
                    rentStart = item.rentStart,
                    rentEnd = item.rentEnd,
                    price = item.price
                }));
            appDbContent.SaveChanges();

            rentCart.clear();
        }
    }
}