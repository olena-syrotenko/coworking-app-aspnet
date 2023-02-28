using CoworkingApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoworkingApp.Data.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipment _equipment;
        private readonly IEquipmentType _equipmentTypes;

        public EquipmentController(IEquipment equipment, IEquipmentType equipmentTypes)
        {
            _equipment = equipment;
            _equipmentTypes = equipmentTypes;
        }
        public ViewResult List()
        {
            var equipment = _equipment.AllEquipment;
            return View(equipment);
        }
    }
}
