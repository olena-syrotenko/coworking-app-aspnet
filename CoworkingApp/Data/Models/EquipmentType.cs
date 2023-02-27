using System.Collections.Generic;

public class EquipmentType
{
    public int id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public List<Equipment> equipment { get; set; }
}