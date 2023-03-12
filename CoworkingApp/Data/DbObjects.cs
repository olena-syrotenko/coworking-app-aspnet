using CoworkingApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Data
{
    public class DbObjects
    {
        private static Dictionary<string, RoomType> roomType;
        private static Dictionary<string, Service> service;
        private static Dictionary<string, Room> room;

        public static void Initial(AppDbContent content)
        {
            if(!content.RoomType.Any())
            {
                content.RoomType.AddRange(RoomTypes.Select(rt => rt.Value));
            }

            if (!content.Service.Any())
            {
                content.Service.AddRange(Services.Select(s => s.Value));
            }

            if (!content.Room.Any())
            {
                content.Room.AddRange(Rooms.Select(r => r.Value));
            }

            if(!content.Place.Any())
            {
                int idCounter = 1;
                content.Place.AddRange(Rooms.SelectMany(item => Enumerable.Range(1, item.Value.maxPlaces)
                                .Select(i => new Place
                                {
                                    id = idCounter++,
                                    code = item.Value.id + "/" + i,
                                    roomId = item.Value.id,
                                    room = item.Value
                                })));
            }

            content.SaveChanges();
        }

        public static Dictionary<string, RoomType> RoomTypes
        {
            get
            {
                if (roomType == null)
                {
                    var roomTypeList = new List<RoomType>
                    {
                        new RoomType {name = "Open space", description = "������� ������ �� ������������� �������� ������"},
                        new RoomType {name = "Lounge zone", description = "������� ������ �� �'����� �������� �� ����������� ����������"},
                        new RoomType {name = "Private office", description = "��������� ��������� ������ ��� 2-3 ���"},
                        new RoomType {name = "Meeting room", description = "ʳ����� ��� ���������� �������� �� ��� ���������� �����������"},
                        new RoomType {name = "Skype room", description = "�������� ������ �� ������ ��� ������"},
                        new RoomType {name = "Business suite", description = "������� ��������� ������ ��� ������� ������"}
                    };
                    roomType = new Dictionary<string, RoomType>();
                    roomTypeList.ForEach(el => roomType.Add(el.name, el));
                }
                return roomType;
            }
        }

        public static Dictionary<string, Service> Services
        {
            get
            {
                if (service == null)
                {
                    var serviceList = new List<Service>
                    {
                        new Service {id = 1, name = "�������� Wi-Fi �'�������" },
                        new Service {id = 2, name = "����������� ������ ����" },
                        new Service {id = 3, name = "������ �� ����" },
                        new Service {id = 4, name = "���������� ����������" },
                        new Service {id = 5, name = "������ �� ���� ���������" },
                        new Service {id = 6, name = "������ �� ���������" },
                        new Service {id = 7, name = "��������� ������ ����" },
                        new Service {id = 8, name = "��������� ����" },
                        new Service {id = 9, name = "������� ������" },
                        new Service {id = 10, name = "������� ��������" },
                        new Service {id = 11, name = "�����" },
                        new Service {id = 12, name = "�������" },
                        new Service {id = 13, name = "�������/������" },
                        new Service {id = 14, name = "������� ������������" },
                    };
                    service = new Dictionary<string, Service>();
                    serviceList.ForEach(el => service.Add(el.name, el));
                }
                return service;
            }
        }

        public static Dictionary<string, Room> Rooms
        {
            get
            {
                if (room == null)
                {
                    var roomList = new List<Room>
                    {
                        new Room
                        {
                            id = 1,
                            name = "Paris",
                            area = 40.5,
                            maxPlaces = 20,
                            price = 120,
                            roomType = RoomTypes["Open space"],
                            imageUrl = "/img/open_space.jpeg",
                            description = "� ��������� �������� ������� ���� ��������� ��������, ���������� ���������, ������� �� ��������. ���� ��������� ������ ��� ����� ����, ������� ������ �� �������������. � �����'�� ���������� �������� ��������� ��������, ����������� ��������� �����, ��, ����� �� ����� �������. ����� ������� ����� ������� ������ �������� �� ����� ��������. � �������� ��������� ������ �������� ���������� ����� ������ �� ����� � ��������� � ��������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                            },
                        },
                        new Room
                        {
                            id = 2,
                            name = "Amsterdam",
                            area = 50,
                            maxPlaces = 15,
                            price = 70,
                            roomType =  RoomTypes["Lounge zone"],
                            description = "������ ���� �������� � ���� ���� - � ������� �����������, ���������� �������, ������� ������� ����� �� ������, ����������, ������������ �������. �����'�� ���������� � ������� ��������� ��� ������� �� ����� ������ �����. ����� ����� � ����� ������, ������ ������ �� ������, �������� �������. ��� �� ���������� ������ ������� �������� ������������� �������, ����� �� ����� �� ������� ���������� ���������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ���� ���������"]
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
                            description = "������-������ ����� � ��� �������� ��������� �� �������� ��������������. �����'�� ������ �������� �� ��������, ����� ���������� ��������, ��������������� �� ����������. ������� ������ ������� ���������� � ���� � ��������� ���� �������. ϳ����� �������� �������� ������ �������� ����. ̳����������� �����'�� �������� ���������� �������-������������� �� ���������� �������� �������.",
                            roomType =  RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite.jpg",
                            services = new List<Service> {  
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                                Services["�����"],
                                Services["��������� ����"],
                                Services["������� ������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 4,
                            name = "London",
                            area = 20,
                            maxPlaces = 4,
                            price = 300,
                            roomType = RoomTypes["Private office"],
                            imageUrl = "/img/private_office.jpeg",
                            description = "��������� ���� ��������� � ����������� ���� � ����������, ���������, ��������, �������. ������ �������� �����'��� ���������� � ������ �������� ����, ��������� ����������� ������, ������, ������� ��� �����. ������ ���� ������������ �������� ������������ ������, ��������, ��������� �� �������� �������. ���������� ������� ������� ����� �������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                                Services["�����"],
                                Services["��������� ����"]
                            }
                        },
                        new Room
                        {
                            id = 5,
                            name = "New York",
                            area = 10,
                            maxPlaces = 1,
                            roomType =  RoomTypes["Meeting room"],
                            price = 250,
                            imageUrl = "/img/meeting_room.jpeg",
                            description = "ʳ����� ��� �������� �������� � �������������� ����, ���� ����� �����'������ ���������� � ���������������. ����������� �������, ��� ������ �����, ������� �� ����� ������, � ��� ������� ���������� ���� ����. ϳ����� �������� � ������� ������. � ����� ����� ������� ������� � �������� �������, ��� ����������� ����������� ����� ����. � ����� ������ ������������ ������� ���������� ���������, �������� ������ ���������� �������� ��������� ������������.",
                             services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������"],
                                Services["�������/������"],
                                Services["������� ������������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 6,
                            name = "Rome",
                            area = 3,
                            maxPlaces = 1,
                            price = 150,
                            roomType =  RoomTypes["Skype room"],
                            imageUrl = "/img/skype_room.jpg",
                            description = "ʳ����� ��� ������ �������� � ����������� ���� ������ � ��������� ���� ���������, �������������, ��������� �� ������� �������. � �����'�� ���������� ���. �� ������� �������� �������, ����� ���� �������� �������������� �������. ����� ������ ����� ������ ����� �������� �� ������������� ��������. ����� ������ ���������� ���������� ������� ������ �������� ����������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������� ������������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 7,
                            name = "Helsinki",
                            area = 25,
                            maxPlaces = 10,
                            price = 100,
                            roomType =  RoomTypes["Open space"],
                            imageUrl = "/img/open_space_helsinki.jpg",
                            description = "³������� ������ ��������� � ��������������� ���� - ���������� �� �������. ³���������� ���������, ������������ �� ��������� ����������� ����. ������, ������, �������� ������� ������ ��������� �� ���������� ��� ������� ��������, �������� ����� �� ��������������. �����'�� ��������� � ������� �����, � �������� � ����������� ��������. ���� ����, ����� � ��������: ����� � ������ �� ������ �����. ������������ ������� ���������� ��������� ����������� ����� ���� �� ������������ ���������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                            },
                        },
                        new Room
                        {
                            id = 8,
                            name = "Marseille",
                            area = 30,
                            maxPlaces = 8,
                            price = 100,
                            roomType =  RoomTypes["Lounge zone"],
                            imageUrl = "/img/lounge_zone_boho.jpeg",
                            description = "������ ���� ������ �������� ����� ������� ���� ����� - ���� ���� ��������� �������, ��������� ����������, � �� ����������� �������, ����� ������������ � ������� ������ �� ���������� ������. ��� ������ ���� ������ ����� ��������� ������ ����, �� ������ ������� �������������� � �� ���������� ���� ������ �������. ������ ����������������� ������, ����������, �������, ������, �� ������� ���� � �������� �� �������� ���, ��������. �� ��������� �����, ���� ��������� ���: �� ��������� �� �������� � ��������. ��������� ����� �� �'���.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ����"],
                            },
                        },
                        new Room
                        {
                            id = 9,
                            name = "Lyon",
                            area = 50,
                            maxPlaces = 10,
                            price = 300,
                            description = "������ ������ ����� ��������� ���������� - ������ ��������� ���������, ������� �����, ������� ����� � ��������� ���������. ������ ������ �������� � ����� ��������: ������ ���, �������� � ��������, ��� �� �������� ����.",
                            roomType = RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite_lyon.jpg",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�����"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 10,
                            name = "Madrid",
                            area = 60,
                            maxPlaces = 10,
                            price = 400,
                            roomType = RoomTypes["Private office"],
                            imageUrl = "/img/private_office_green.jpg",
                            description = "��������� ���� ����������� �������� ������ ����� � �����'��, �� ���������������� ������� ������ �� ���������, � ����� ������ ����� � ������ ����� �� ������� ������. ³� �������� �������� ��������� ��������� ��� ��� ����, � �������� ��� ���, ��� ���� ������ ������ �� ������ ����㳿 � ��� ������� ����.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                                Services["�����"],
                                Services["������� ��������"]
                            }
                        },
                        new Room
                        {
                            id = 11,
                            name = "Seul",
                            area = 6,
                            maxPlaces = 1,
                            roomType =  RoomTypes["Meeting room"],
                            price = 180,
                            imageUrl = "/img/small_meeting_room.jpg",
                            description = "����������� ������ �������� � ���� ���-���, ���� ��������������� ������������� �������� ��������� �� ��������. � �����'�� � ������� �����������, ����, �������, � ����� ������ ��������� ������� �� ���������. �� ��������� ��������, �������� �� �������������� �����'�� ��� ���������� ������������ ��������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������� ������������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 12,
                            name = "Ansan",
                            area = 2,
                            maxPlaces = 1,
                            price = 120,
                            roomType =  RoomTypes["Skype room"],
                            imageUrl = "/img/skype_room_ansan.jpg",
                            description = "ʳ����� ��� ������ �������� � ��������� ��������� ������� - ������� �����, ��������� ������ �� ������������ ����� ��������, ����� �� ����, ����� �� �������. ����������� ����� ������ � ������������ ������� ������������ ����, ����������� �������� �� �������� ����������� �������. ���� ����� ���������� �����, ����� ������� �� ������� �����.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 13,
                            name = "Prague",
                            area = 80,
                            maxPlaces = 30,
                            price = 180,
                            roomType =  RoomTypes["Open space"],
                            imageUrl = "/img/open_space_big.jpg",
                            description = "³������� ������ ��������� � ���� ������. �� �������� ������� �� ������� ����� �����'�� ����� �� ���������� ����� ��� ��������� ������. ʳ����� ��������� �������� ������ ������� ���������� ���������� �����, � ����� ����������� ����� ������ ��������� ������� ������� �����������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�������/������"]
                            },
                        },
                        new Room
                        {
                            id = 14,
                            name = "Bern",
                            area = 40,
                            maxPlaces = 10,
                            price = 150,
                            roomType =  RoomTypes["Lounge zone"],
                            imageUrl = "/img/lounge_zone_circle.jpg",
                            description = "�������� ���������� ���� ������ ���� � ���������� ������������ ������� ����, ���� ������� ������� ������� �������� �� ������� ������� �����. �� ������ ������� �'�� ����� ��� �����'�� ����, ��������� ����������� �� ������ ��������� ��������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ���� ���������"],
                            },
                        },
                        new Room
                        {
                            id = 15,
                            name = "Chicago",
                            area = 40,
                            maxPlaces = 8,
                            price = 450,
                            description = "������ ������ ��������� � ������ �������� �����, �� ������������ �� ������������ �� ������� ������ ���������. ��������� ������ ��������� ����������� ��� ������������ ����������� �� ������� �������� �� �������� ������ ��� ��������� �������� ����������.",
                            roomType = RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite_tech.png",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�����"],
                                Services["������� ������������"],
                                Services["������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 16,
                            name = "Atlanta",
                            area = 8,
                            maxPlaces = 2,
                            price = 300,
                            roomType = RoomTypes["Private office"],
                            imageUrl = "/img/private_office_two_people.jpg",
                            description = "��������� ��������� ���� ������� ���� ��� ���� ��� ����������� ��� ����������� ��������������� � ����� �� ��������� ������� ����. �����'�� ������������ � � ������ �����, ��� ���'�������� ������ �� � ������ �������� ������� ����������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�����"],
                            }
                        },
                        new Room
                        {
                            id = 17,
                            name = "Las Vegas",
                            area = 20,
                            maxPlaces = 1,
                            roomType =  RoomTypes["Meeting room"],
                            price = 250,
                            imageUrl = "/img/meeting_room_open.jpg",
                            description = "���������� ����������� ������ � ���� ��������� �������� ��� ���� ������������ �� ������������ �����'����. ������������ ������ � ��������� �� �'�� ����� ������ ���������� ��� �� ���������� ��� �� ����� ������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������� ��������"],
                                Services["�������"],

                            },
                        },
                        new Room
                        {
                            id = 18,
                            name = "Toronto",
                            area = 3,
                            maxPlaces = 1,
                            price = 80,
                            roomType =  RoomTypes["Skype room"],
                            imageUrl = "/img/skype_room_black.jpg",
                            description = "�������� ������ ��� ������ ��������� ��� ���������� ��� ��������� ������: ������, ������ ����� ����� ����������, ������� ������ �� �������� ����������. �����'�� ������������� � ���-������ �������� ������� � �������� ��������� ������, � ���� ��������� ��������� ������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������ �� ����"]
                            },
                        },
                        new Room
                        {
                            id = 19,
                            name = "Dublin",
                            area = 40,
                            maxPlaces = 10,
                            price = 120,
                            roomType =  RoomTypes["Open space"],
                            imageUrl = "/img/open_space_industrial.jpeg",
                            description = "��������� �������� ������ � �������������� ���� �������� ����� ��� ���, ��� ��������� ��������� � ���������� �� �������������� ������. ���������� ������ �����'��� � ������������� ������������ �������� �� ���� ������ ��������� ������ �������� ��������� �� ������������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"]
                            },
                        },
                        new Room
                        {
                            id = 20,
                            name = "Oxford",
                            area = 15,
                            maxPlaces = 1,
                            roomType =  RoomTypes["Meeting room"],
                            price = 300,
                            imageUrl = "/img/meeting_room_big.jpg",
                            description = "ʳ����� ��� �������� �������� � ���������� ���������� ���� �� ��������� ��� ���������� ��� ���������� ������ ��������: ������� ���������� ��� ������������ ��������, ������� ��������� ���, ����� ����� �� �������� ����, �� ��������� ������ ������� ������� �����. �� ������ �������� ������ ���������� �������� ������ ������� �������� �����. ����� ������� � ������ �� ������, �� ���������� ��������� ���������� �� ���������.",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������� ��������"],
                                Services["�������"],
                                Services["������� ������������"],
                                Services["������ �� ����"],
                            },
                        },
                    };
                    room = new Dictionary<string, Room>();
                    roomList.ForEach(el => room.Add(el.name, el));
                }
                return room;
            }
        }
    }
}