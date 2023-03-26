using System;

namespace CoworkingApp.Data.Models
{
    public class RentCartItem
    {
        public int id { get; set; }
        public int placeId {get;set;}
        public Place place { get; set; }
        public DateTime rentStart { get; set; }
        public DateTime rentEnd { get; set; }
        public double price { get; set; }
        public string rentCartId { get; set; }
    }
}