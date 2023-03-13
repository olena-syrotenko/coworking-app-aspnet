using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Room> favouriteRooms { get; set; }

    }
}