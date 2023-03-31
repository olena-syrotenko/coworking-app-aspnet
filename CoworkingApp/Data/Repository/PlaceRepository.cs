using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Data.Repository
{
	public class PlaceRepository : IPlace
	{
        private static readonly List<string> activeStatuses = new List<string> { "Нова", "Підтверджено" };
		private readonly AppDbContent appDbContent;

		public PlaceRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

        public IEnumerable<Place> AllPlaces => appDbContent.Place.Include(p => p.room.roomType).Include(p => p.room.services);

        public Place getAvailableInRoom(DateTime rentStart, DateTime rentEnd, int roomId)
        {
            IEnumerable<int> placesInRentApplications = appDbContent.RentApplication.Include(ra => ra.status).Include(ra => ra.rentDetails)
                .AsEnumerable()
                .Where(ra => activeStatuses.Contains(ra.status.name))
                .SelectMany(ra => ra.rentDetails)
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
            return null;
        }

        public Place getById(int id) => appDbContent.Place.FirstOrDefault(p => p.id == id);

        private bool isOverlapped(DateTime rentStartToCheck, DateTime rentEndToCheck, DateTime rentStart, DateTime rentEnd)
        {
            return rentStartToCheck <= rentEnd && rentStart <= rentEndToCheck;
        }
    }
}