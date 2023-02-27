using System.Collections.Generic;

public class MockEquipmentType : IEquipmentType
{
    public IEnumerable<EquipmentType> AllEquipmentTypes
    {
        get
        {
            return new List<EquipmentType>
            {
                new EquipmentType {name = "Клавіатура", price = 120},
                new EquipmentType {name = "Комп'ютерна миша", price = 50},
                new EquipmentType {name = "Монітор", price = 200},
                new EquipmentType {name = "USB-хаб", price = 30},
                new EquipmentType {name = "Графічний планшет", price = 500},
                new EquipmentType {name = "Навушники", price = 50}
            };
        }
    }
}