using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Utils;
using System;
using System.Linq;

namespace CoworkingApp.Data.Repository
{
    public class RentApplicationRepository : IRentApplication
    {
        private readonly RentCart rentCart;
        private readonly AppDbContent appDbContent;

        public RentApplicationRepository(AppDbContent appDbContent, RentCart rentCart)
        {
            this.appDbContent = appDbContent;
            this.rentCart = rentCart;
        }

        public void createRentApplication(RentApplication rentApplication)
        {
            rentApplication.createTime = DateTime.Now;
            rentApplication.totalPrice = rentCart.getRentItems().Sum(item => CalculationUtil.getTotalForPlace(item.place, item.rentStart, item.rentEnd));

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