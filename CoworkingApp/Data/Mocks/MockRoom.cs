using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Data.Mocks
{
	public class MockRoom : IRoom
	{
		private readonly IRoomType _roomType = new MockRoomType();
		public IEnumerable<Room> AllRooms
		{
			get
			{
				return new List<Room>
			{
				new Room
				{
					id = 1,
					name = "Paris",
					area = 40.5,
					maxPlaces = 20,
					price = 120,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Open space")).First(),
					imageUrl = "/img/open_space.jpeg",
					services = new List<Service> {
						new Service {name = "�������� Wi-Fi �'�������" },
						new Service {name = "����������� ������ ����" },
						new Service {name = "������ �� ����" },
						new Service {name = "���������� ����������" },
						new Service {name = "������ �� ���� ���������" },
						new Service {name = "������ �� ���������" },
					},
				},
				new Room
				{
					id = 2,
					name = "Amsterdam",
					area = 50,
					maxPlaces = 15,
					price = 70,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Lounge zone")).First(),
					services = new List<Service> {
						new Service {name = "�������� Wi-Fi �'�������" },
						new Service {name = "����������� ������ ����" },
						new Service {name = "������ �� ���� ���������" }
					},
					imageUrl = "/img/lounge_zone.jpg",
				},
				new Room
				{
					id = 3,
					name = "Tokyo",
					area = 100,
					maxPlaces = 20,
					price = 500,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Business suite")).First(),
					imageUrl = "/img/business_suite.jpg",
					services = new List<Service> { new Service { name = "�������� Wi-Fi �'�������" },
						new Service {name = "��������� ������ ����" },
						new Service {name = "������ �� ����" },
						new Service {name = "���������� ����������" },
						new Service {name = "������ �� ���� ���������" },
						new Service {name = "������ �� ���������" },
						new Service {name = "�����" },
						new Service {name = "��������� ����" },
						new Service {name = "������� ������" },
						new Service {name = "������� ��������" }
					},
				},
				new Room
				{
					id = 4,
					name = "London",
					area = 20,
					maxPlaces = 4,
					price = 300,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Private office")).First(),
					imageUrl = "/img/private_office.jpeg",
					services = new List<Service> {
						new Service {name = "�������� Wi-Fi �'�������" },
						new Service {name = "��������� ������ ����" },
						new Service {name = "������ �� ����" },
						new Service {name = "���������� ����������" },
						new Service {name = "������ �� ���� ���������" },
						new Service {name = "������ �� ���������" },
						new Service {name = "�����" },
						new Service {name = "��������� ����" }
					}
				},
				 new Room
				{
					id = 5,
					name = "New York",
					area = 10,
					maxPlaces = 10,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Meeting room")).First(),
					price = 250,
					imageUrl = "/img/meeting_room.jpeg",
					services = new List<Service> {
						new Service {name = "�������� Wi-Fi �'�������" },
						new Service {name = "�������" },
						new Service {name = "�������/������" },
						new Service {name = "������� ������������" },
						new Service {name = "������� ��������" }
					},
				},
				  new Room
				{
					id = 6,
					name = "Rome",
					area = 3,
					maxPlaces = 1,
					price = 150,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Skype room")).First(),
					imageUrl = "/img/skype_room.jpg",
					services = new List<Service> {
						new Service {name = "�������� Wi-Fi �'�������" },
						new Service {name = "������� ������������" },
						new Service {name = "������� ��������" }
					},
				}
			};
			}
		}

		public IEnumerable<Room> PopularRooms { get; }

		public Room getById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}