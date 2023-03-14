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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("open space")).First(),
					imageUrl = "/img/open_space.jpeg",
					isFavourite = false,
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("lounge zone")).First(),
					isFavourite = true,
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("business suite")).First(),
					imageUrl = "/img/business_suite.jpg",
					isFavourite = false,
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("private office")).First(),
					imageUrl = "/img/private_office.jpeg",
					isFavourite = true,
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("meeting room")).First(),
					price = 250,
					imageUrl = "/img/meeting_room.jpeg",
					isFavourite = false,
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("skype room")).First(),
					imageUrl = "/img/skype_room_black.jpg",
					isFavourite = true,
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

        public IEnumerable<Room> FavouriteRooms { get; }

        public Room getById(int id)
		{
			throw new System.NotImplementedException();
		}

        public IEnumerable<Room> getByRoomType(string roomTypeName)
        {
            throw new System.NotImplementedException();
        }
    }
}