using System.Collections.Generic;
using System.Linq;

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
                    name = "Paris",
                    area = 40.5,
                    maxPlaces = 20,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Open space")).First(),
                    imageUrl = "https://www.coworker.com/mag/wp-content/uploads/2017/10/NEST-@-TRYP-hotel-1280x640.jpg",
                    services = new List<string> {"Швидкісне Wi-Fi з'єднання", "Незакріплене робоче місце", "Доступ до кухні", "Електронна перепустка", "Доступ до зони відпочинку", "Доступ до спортзалу"},
                    tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Day, pricePerUnit = 120},
                        new Tariff { timeUnit = TimeUnit.Week, pricePerUnit = 400},
                        new Tariff { timeUnit = TimeUnit.Month, pricePerUnit = 1000},
                    }
                },
                new Room
                {
                    name = "Amsterdam",
                    area = 50,
                    maxPlaces = 15,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Lounge zone")).First(),
                    services = new List<string> { "Швидкісне Wi-Fi з'єднання", "Незакріплене робоче місце", "Доступ до зони відпочинку"},
                    imageUrl = "https://s3.seattlebusinessmag.com/wp-content/uploads/2022/07/cloud-bar.jpg",
                                        tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Day, pricePerUnit = 70},
                    }
                },
                new Room
                {
                    name = "Tokyo",
                    area = 100,
                    maxPlaces = 20,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Bussiness suite")).First(), 
                    imageUrl = "https://content.office-hub.com/wp-content/uploads/2018/07/wework-private-office.jpg",
                    services = new List<string> {"Швидкісне Wi-Fi з'єднання", "Закріплене робоче місце", "Доступ до кухні", "Електронна перепустка", "Доступ до зони відпочинку", "Доступ до спортзалу", "Локер", "Гостьовий візит", "Послуги юриста", "Технічна підтримка"},
                    tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Week, pricePerUnit = 2000},
                        new Tariff { timeUnit = TimeUnit.Month, pricePerUnit = 5000},
                    }
                },
                new Room
                {
                    name = "London",
                    area = 20,
                    maxPlaces = 4,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Private office")).First(),
                    imageUrl = "https://content.office-hub.com/wp-content/uploads/2018/07/wework-enterprise-private-offices.jpg",
                    services = new List<string> {"Швидкісне Wi-Fi з'єднання", "Закріплене робоче місце", "Доступ до кухні", "Електронна перепустка", "Доступ до зони відпочинку", "Доступ до спортзалу", "Локер", "Гостьовий візит"},
                    tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Day, pricePerUnit = 300},
                        new Tariff { timeUnit = TimeUnit.Week, pricePerUnit = 1500},
                        new Tariff { timeUnit = TimeUnit.Month, pricePerUnit = 3000},
                    }
                },
                 new Room
                {
                    name = "New York",
                    area = 10,
                    maxPlaces = 10,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Meeting room")).First(),
                    imageUrl = "https://content.office-hub.com/wp-content/uploads/2018/07/WeWork_Pyrmont-4.jpg",
                    services = new List<string> {"Швидкісне Wi-Fi з'єднання", "Фліпчарт", "Принтер/сканер", "Технічне забезпечення", "Технічна підтримка"},
                    tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Day, pricePerUnit = 250}
                    }
                },
                  new Room
                {
                    name = "Rome",
                    area = 3,
                    maxPlaces = 1,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Skype room")).First(),
                    imageUrl = "https://officesnapshots.com/wp-content/uploads/2015/04/github-office-design-19-768x512.jpg",
                    services = new List<string> {"Швидкісне Wi-Fi з'єднання", "Технічне забезпечення", "Технічна підтримка"},
                    tariffs = new List<Tariff> {
                        new Tariff { timeUnit = TimeUnit.Day, pricePerUnit = 150}
                    }
                }
            };
        }
    }

    public IEnumerable<Room> PopularRooms { get; set; }

    public Room getById(int id)
    {
        throw new System.NotImplementedException();
    }
}