using System.Collections.Generic;
using System.Linq;

public class MockEquipment : IEquipment
{
    private IEquipmentType _equipmentType = new MockEquipmentType();
    public IEnumerable<Equipment> AllEquipment
    {
        get
        {
            return new List<Equipment>
            {
                new Equipment
                {
                    model = "KV-300H",
                    brand = "A4Tech",
                    description = "��� ���������: ������, ���������: �������, �����: ������������, �����",
                    imageUrl = "https://content2.rozetka.com.ua/goods/images/big/88330240.jpg",
                    equipmentType = _equipmentType.AllEquipmentTypes.Where(type => type.name.Equals("���������")).First(),
                },
                new Equipment
                {
                    model = "MF220",
                    brand = "2�",
                    description = "ϳ�'�������: ����������, ����� ����: ��������, ����������: ��� �������, ��� ���� ��� (����������� ������)",
                    imageUrl = "https://content.rozetka.com.ua/goods/images/big/203636775.jpg",
                    equipmentType = _equipmentType.AllEquipmentTypes.Where(type => type.name.Equals("����'������ ����")).First(),
                },
                new Equipment
                {
                    model = "C27F396F",
                    brand = "Samsung",
                    description = "ĳ������� �������: 27, ��� ������� �������: 4 ��, ��� �������: VA",
                    imageUrl = "https://content2.rozetka.com.ua/goods/images/big/106661765.jpg",
                    equipmentType = _equipmentType.AllEquipmentTypes.Where(type => type.name.Equals("������")).First(),
                },
                new Equipment
                {
                    model = "A-AMU3-4P-01",
                    brand = "Cablexpert",
                    description = "4 ����� SuperSpeed USB 3.0",
                    imageUrl = "https://content1.rozetka.com.ua/goods/images/big/247884601.jpg",
                    equipmentType = _equipmentType.AllEquipmentTypes.Where(type => type.name.Equals("USB-���")).First(),
                },
                new Equipment
                {
                    model = "HG350",
                    brand = "2E",
                    description = "�����������, ������, ���������� ̳������, ��� ��������� ��������������",
                    imageUrl = "https://content1.rozetka.com.ua/goods/images/big/247773979.jpg",
                    equipmentType = _equipmentType.AllEquipmentTypes.Where(type => type.name.Equals("���������")).First(),
                },
            };
        }
    }

    public Equipment getById(int id)
    {
        throw new System.NotImplementedException();
    }
}