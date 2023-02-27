using System.Collections.Generic;

namespace CoworkingApp.Data.Models
{
    public class EquipmentType
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public List<Equipment> equipment { get; set; }
    }
}