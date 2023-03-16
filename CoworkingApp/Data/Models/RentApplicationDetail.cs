using System;

namespace CoworkingApp.Data.Models
{
    public class RentApplicationDetail
    {
        public int id { get; set; }
        public int rentApplicationId { get; set; }
        public int placeId { get; set; }
        public double price { get; set; }
        public DateTime rentStart { get; set; }
        public DateTime rentEnd { get; set; }
        public virtual Place place { get; set; }
        public virtual RentApplication rentApplication { get; set; }
    }
}