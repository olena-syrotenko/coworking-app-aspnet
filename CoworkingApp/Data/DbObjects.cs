using CoworkingApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoworkingApp.Data
{
    public class DbObjects
    {
        private static Dictionary<string, RoomType> roomType;
        private static Dictionary<string, Service> service;
        private static Dictionary<string, Room> room;
        private static Dictionary<string, IdentityRole> role;
        private static Dictionary<User, IdentityRole> user;
        private static Dictionary<string, string> userCred;
        private static Dictionary<string, Status> status;

        public static void Initial(AppDbContent content)
        {
            if (!content.Status.Any())
            {
                content.Status.AddRange(Statuses.Select(r => r.Value));
            }

            if (!content.RoomType.Any())
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

        public static async Task InitialAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(!roleManager.Roles.Any())
            {
                foreach (var roleEl in Roles.Values)
                {
                    await roleManager.CreateAsync(roleEl);
                }
            }

            if(!userManager.Users.Any())
            {
                
                foreach (var userEl in Users.Keys)
                {
                    IdentityResult result = await userManager.CreateAsync(userEl, userCred[userEl.Email]);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(userEl, Users[userEl].Name);
                    }
                }
            }
        }

        public static Dictionary<string, IdentityRole> Roles
        {
            get
            {
                if (role == null)
                {
                    var roleList = new List<IdentityRole>
                    {
                        new IdentityRole {Name = "Admin",},
                        new IdentityRole {Name = "User",},
                    };
                    role = new Dictionary<string, IdentityRole>();
                    roleList.ForEach(el => role.Add(el.Name, el));
                }
                return role;
            }
        }

        public static Dictionary<User, IdentityRole> Users
        {
            get
            {
                if (user == null)
                {
                    user = new Dictionary<User, IdentityRole>();
                    userCred = new Dictionary<string, string>();

                    var simpleUser = new User 
                    {
                        Email = "testUser@mail.com",
                        UserName = "testUser@mail.com",
                        name = "Olena",
                        birthDate = DateTime.Parse("17/03/2003"),
                    };
                    user.Add(simpleUser, Roles["User"]);
                    userCred.Add(simpleUser.Email, "userPass1!");

                    var admin = new User
                    {
                        Email = "testAdmin@mail.com",
                        UserName = "testAdmin@mail.com",
                        name = "Admin",
                        birthDate = DateTime.Parse("01/01/2000"),
                    };
                    user.Add(admin, Roles["Admin"]);
                    userCred.Add(admin.Email, "adminPass1!");
                }
                return user;
            }
        }

        public static Dictionary<string, Status> Statuses
        {
            get
            {
                if (status == null)
                {
                    var statusList = new List<Status>
                    {
                        new Status {name = "����",},
                        new Status {name = "ϳ����������",},
                        new Status {name = "³�������",},
                        new Status {name = "���������",}
                    };
                    status = new Dictionary<string, Status>();
                    statusList.ForEach(el => status.Add(el.name, el));
                }
                return status;
            }
        }

        public static Dictionary<string, RoomType> RoomTypes
        {
            get
            {
                if (roomType == null)
                {
                    var roomTypeList = new List<RoomType>
                    {
                        new RoomType {name = "open space", description = "������� ������ �� ������������� �������� ������"},
                        new RoomType {name = "lounge zone", description = "������� ������ �� �'����� �������� �� ����������� ����������"},
                        new RoomType {name = "private office", description = "��������� ��������� ������ ��� 2-3 ���"},
                        new RoomType {name = "meeting room", description = "ʳ����� ��� ���������� �������� �� ��� ���������� �����������"},
                        new RoomType {name = "skype room", description = "�������� ������ �� ������ ��� ������"},
                        new RoomType {name = "business suite", description = "������� ��������� ������ ��� ������� ������"}
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
                        new Service {id = 3, name = "������ �� �����" },
                        new Service {id = 4, name = "���������� ����������" },
                        new Service {id = 5, name = "������ �� ���� ���������" },
                        new Service {id = 6, name = "������ �� ���������" },
                        new Service {id = 7, name = "��������� ������ ����" },
                        new Service {id = 8, name = "��������� ����" },
                        new Service {id = 9, name = "������� ������" },
                        new Service {id = 10, name = "�������� ��������" },
                        new Service {id = 11, name = "�����" },
                        new Service {id = 12, name = "�������" },
                        new Service {id = 13, name = "�������/������" },
                        new Service {id = 14, name = "�������� ������������" },
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
                            roomType = RoomTypes["open space"],
                            isFavourite = false,
                            imageUrl = "/img/open_space.jpeg",
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� �����"],
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
                            roomType =  RoomTypes["lounge zone"],
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ���� ���������"]
                            },
                            imageUrl = "/img/lounge_zone.jpg",
                            isFavourite = true,
                        },
                        new Room
                        {
                            id = 3,
                            name = "Tokyo",
                            area = 100,
                            maxPlaces = 20,
                            price = 500,
                            roomType =  RoomTypes["business suite"],
                            imageUrl = "/img/business_suite.jpg",
                            isFavourite = false,
                            services = new List<Service> {  
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� �����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                                Services["�����"],
                                Services["��������� ����"],
                                Services["������� ������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 4,
                            name = "London",
                            area = 20,
                            maxPlaces = 4,
                            price = 300,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office.jpeg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� �����"],
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
                            roomType =  RoomTypes["meeting room"],
                            price = 250,
                            imageUrl = "/img/meeting_room.jpeg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������"],
                                Services["�������/������"],
                                Services["�������� ������������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 6,
                            name = "Rome",
                            area = 3,
                            maxPlaces = 1,
                            price = 150,
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room_black.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������� ������������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 7,
                            name = "Helsinki",
                            area = 25,
                            maxPlaces = 10,
                            price = 100,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_helsinki.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� �����"],
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
                            roomType =  RoomTypes["lounge zone"],
                            imageUrl = "/img/lounge_zone_boho.jpeg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� �����"],
                            },
                        },
                        new Room
                        {
                            id = 9,
                            name = "Lyon",
                            area = 50,
                            maxPlaces = 10,
                            price = 300,
                            roomType = RoomTypes["business suite"],
                            imageUrl = "/img/business_suite_lyon.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� �����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�����"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 10,
                            name = "Madrid",
                            area = 60,
                            maxPlaces = 10,
                            price = 400,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office_green.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� �����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["������ �� ���������"],
                                Services["�����"],
                                Services["�������� ��������"]
                            }
                        },
                        new Room
                        {
                            id = 11,
                            name = "Seul",
                            area = 6,
                            maxPlaces = 1,
                            roomType =  RoomTypes["meeting room"],
                            price = 180,
                            imageUrl = "/img/small_meeting_room.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������� ������������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 12,
                            name = "Ansan",
                            area = 2,
                            maxPlaces = 1,
                            price = 120,
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room_ansan.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 13,
                            name = "Prague",
                            area = 80,
                            maxPlaces = 30,
                            price = 180,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_big.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["����������� ������ ����"],
                                Services["������ �� �����"],
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
                            roomType =  RoomTypes["lounge zone"],
                            imageUrl = "/img/lounge_zone_circle.jpg",
                            isFavourite = false,
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
                            roomType = RoomTypes["business suite"],
                            imageUrl = "/img/business_suite_tech.png",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� �����"],
                                Services["���������� ����������"],
                                Services["������ �� ���� ���������"],
                                Services["�����"],
                                Services["�������� ������������"],
                                Services["�������� ��������"]
                            },
                        },
                        new Room
                        {
                            id = 16,
                            name = "Atlanta",
                            area = 8,
                            maxPlaces = 2,
                            price = 300,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office_two_people.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["��������� ������ ����"],
                                Services["������ �� �����"],
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
                            roomType =  RoomTypes["meeting room"],
                            price = 250,
                            imageUrl = "/img/meeting_room_open.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������� ��������"],
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
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["������ �� �����"]
                            },
                        },
                        new Room
                        {
                            id = 19,
                            name = "Dublin",
                            area = 40,
                            maxPlaces = 10,
                            price = 120,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_industrial.jpeg",
                            isFavourite = false,
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
                            roomType =  RoomTypes["meeting room"],
                            price = 300,
                            imageUrl = "/img/meeting_room_big.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["�������� Wi-Fi �'�������"],
                                Services["�������� ��������"],
                                Services["�������"],
                                Services["�������� ������������"],
                                Services["������ �� �����"],
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