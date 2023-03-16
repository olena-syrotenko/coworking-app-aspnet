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
		private readonly AppDbContent appDbContent;

		public PlaceRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

        public IEnumerable<Place> AllPlaces => appDbContent.Place.Include(p => p.room.roomType).Include(p => p.room.services);

        public Place getAvailableInRoom(int roomId, DateTime rentStart, DateTime rentEnd)
        {
            throw new NotImplementedException();
        }

        public Place getById(int id) => appDbContent.Place.FirstOrDefault(p => p.id == id);
    }
}