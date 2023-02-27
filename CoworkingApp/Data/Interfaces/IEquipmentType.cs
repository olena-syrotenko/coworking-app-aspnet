using System.Collections.Generic;

public interface IEquipmentType
{
    IEnumerable<EquipmentType> AllEquipmentTypes { get; }
}