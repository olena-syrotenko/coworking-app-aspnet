using System.Collections.Generic;

public interface IEquipment
{
    IEnumerable<Equipment> AllEquipment { get; }
    Equipment getById(int id);
}