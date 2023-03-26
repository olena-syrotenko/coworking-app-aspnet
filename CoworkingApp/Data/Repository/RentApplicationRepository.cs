using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            rentApplication.totalPrice = rentCart.totalPrice;

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
        }

        public Place getAvailablePlaceInRoom(DateTime rentStart, DateTime rentEnd, int roomId)
        {
            IEnumerable<int> placesInRentApplications = appDbContent.RentApplicationDetail
                .AsEnumerable()
                .Where(rp => isOverlapped(rentStart, rentEnd, rp.rentStart, rp.rentEnd))
                .Select(rp => rp.placeId);
            IEnumerable<int> placesInRentCarts = appDbContent.RentCartItem
                .AsEnumerable()
                .Where(rc => isOverlapped(rentStart, rentEnd, rc.rentStart, rc.rentEnd))
                .Select(rc => rc.placeId);
            return appDbContent.Place
                .Where(p => p.roomId == roomId && !(placesInRentApplications.Contains(p.id) || placesInRentCarts.Contains(p.id)))
                .Include(p => p.room)
                .FirstOrDefault();
        }

        private bool isOverlapped(DateTime rentStartToCheck, DateTime rentEndToCheck, DateTime rentStart, DateTime rentEnd)
        {
            return rentStartToCheck <= rentEnd && rentStart <= rentEndToCheck;
        }
    }
}