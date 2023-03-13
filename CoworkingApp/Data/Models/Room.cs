using System.Collections.Generic;

namespace CoworkingApp.Data.Models
{
	public class Room
	{
		public int id { set; get; }
		public string name { set; get; }
		public double area { set; get; }
		public int maxPlaces { set; get; }
		public double price { set; get; }
		public string imageUrl { set; get; }
		public bool isFavourite { set; get; }
		public List<Service> services { set; get; }
		public int roomTypeId { set; get; }
		public virtual RoomType roomType { set; get; }
		public List<Place> places { get; set; }
	}
}
