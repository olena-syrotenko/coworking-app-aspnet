using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
    public interface IRentApplication
    {
        void createRentApplication(RentApplication rentApplication);
        IEnumerable<RentApplication> AllRentApplications { get; }
        IEnumerable<RentApplication> getByUserId(string userId);
        RentApplication getById(int id);
    }
}
