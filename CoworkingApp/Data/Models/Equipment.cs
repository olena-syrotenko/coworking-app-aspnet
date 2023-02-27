public class Equipment
{
    public int id { get; set; }
    public string model { get; set; }
    public string brand { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public int availableAmount { get; set; }
    public int equipmentTypeId { get; set; }
    public virtual EquipmentType equipmentType { get; set; }
}