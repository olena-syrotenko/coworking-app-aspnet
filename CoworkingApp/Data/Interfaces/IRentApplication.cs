using CoworkingApp.Data.Models;
using System;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
    public interface IRentApplication
    {
        Place getAvailablePlaceInRoom(DateTime rentStart, DateTime rentEnd, int roomId);
        void createRentApplication(RentApplication rentApplication);
    }
}
