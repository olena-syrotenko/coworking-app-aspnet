using CoworkingApp.Data.Models;
using System;

namespace CoworkingApp.Data.Utils
{
    public class CalculationUtil
    {
        public static double getTotalForPlace(Place place, DateTime start, DateTime end)
        {
            return place.room.price * ((end - start).Days + 1);
        }
    }
}