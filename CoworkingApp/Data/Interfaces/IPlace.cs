using CoworkingApp.Data.Models;
using System;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IPlace
	{
		IEnumerable<Place> AllPlaces { get; }
		Place getById(int id);
		Place getAvailableInRoom(DateTime rentStart, DateTime rentEnd, int roomId);
	}
}