using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Mocks
{
	public class MockEquipmentType : IEquipmentType
	{
		public IEnumerable<EquipmentType> AllEquipmentTypes
		{
			get
			{
				return new List<EquipmentType>
			{
				new EquipmentType {name = "���������", price = 120},
				new EquipmentType {name = "����'������ ����", price = 50},
				new EquipmentType {name = "������", price = 200},
				new EquipmentType {name = "USB-���", price = 30},
				new EquipmentType {name = "��������� �������", price = 500},
				new EquipmentType {name = "���������", price = 50}
			};
			}
		}
	}
}