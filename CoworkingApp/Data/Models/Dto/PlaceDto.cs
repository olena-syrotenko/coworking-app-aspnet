using System;

namespace CoworkingApp.Data.Models.Dto
{
    public class PlaceDto
    {
        public int placeId { get; set; }
        public Place place { get; set; }
        public DateTime rentStart { get; set; }
        public DateTime rentEnd { get; set; }
    }
}