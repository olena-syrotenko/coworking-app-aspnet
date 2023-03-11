using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Models.Utils;
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
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Open space")).First(),
					imageUrl = "/img/open_space.jpeg",
					description = "У відкритому робочому просторі панує атмосфера провансу, провінційна романтика, затишок та простота. Вона дозволить забути про міську суєту, досягти спокою та умиротворення. В інтер'єрі використані виключно натуральні матеріали, переважають приглушені зелені, білі, рожеві та бежеві кольори. Серед прикрас можна помітити вінтажні предмети та ковані елементи. З функцією освітлення кімнати ідеально впораються великі люстри та лампи з абажурами з текстилю.",
                    services = new List<Service> {
                        new Service {name = "Швидкісне Wi-Fi з'єднання" },
                        new Service {name = "Незакріплене робоче місце" },
                        new Service {name = "Доступ до кухні" },
                        new Service {name = "Електронна перепустка" },
                        new Service {name = "Доступ до зони відпочинку" },
                        new Service {name = "Доступ до спортзалу" },
                    },
                    tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Day"}, pricePerUnit = 120},
						new Tariff { timeUnit = new TimeUnit { name = "Week"}, pricePerUnit = 400},
						new Tariff { timeUnit = new TimeUnit { name = "Month"}, pricePerUnit = 1000},
					}
				},
				new Room
				{
					id = 2,
					name = "Amsterdam",
					area = 50,
					maxPlaces = 15,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Lounge zone")).First(),
					description = "Лаундж зона виконана в стилі лофт - з мінімумом перегородок, лаконічними формами, великою кількістю світла та повітря, агресивним, «необтесаним» настроєм. Інтер'єр оформлений у холодній кольоровій гамі металіка та різних відтінків сірого. Серед меблів – шкіряні дивани, відкриті полиці та стелажі, журнальні столики. Все це доповнюють велику кількість сучасних освітлювальних приладів, жалюзі на вікнах та картини маловідомих художників.",
					services = new List<Service> {
						new Service {name = "Швидкісне Wi-Fi з'єднання" },
						new Service {name = "Незакріплене робоче місце" },
						new Service {name = "Доступ до зони відпочинку" }
					},
					imageUrl = "/img/lounge_zone.jpg",
					tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Day"}, pricePerUnit = 70},
					}
				},
				new Room
				{
					id = 3,
					name = "Tokyo",
					area = 100,
					maxPlaces = 20,
					description = "Бізнес-простір поєднує в собі японську філософію та принципи конструктивізму. Інтер'єр кімнати базується на манімалізмі, чіткій організації простору, функціональності та стриманості. Основна палітра кольорів складається з білих і неяскраво сірих кольорів. Підлога укладена ламінатом світлих деревних тонів. Мінімалістичний інтер'єр органічно доповнений меблями-трансформером та розсувними скляними дверима.",
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Business suite")).First(),
					imageUrl = "/img/business_suite.jpg",
					services = new List<Service> { new Service { name = "Швидкісне Wi-Fi з'єднання" },
						new Service {name = "Закріплене робоче місце" },
						new Service {name = "Доступ до кухні" },
						new Service {name = "Електронна перепустка" },
						new Service {name = "Доступ до зони відпочинку" },
						new Service {name = "Доступ до спортзалу" },
						new Service {name = "Локер" },
						new Service {name = "Гостьовий візит" },
						new Service {name = "Послуги юриста" },
						new Service {name = "Технічна підтримка" }
						},
					tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Week"}, pricePerUnit = 2000},
						new Tariff { timeUnit = new TimeUnit { name = "Month"}, pricePerUnit = 5000},
					}
				},
				new Room
				{
					id = 4,
					name = "London",
					area = 20,
					maxPlaces = 4,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Private office")).First(),
					imageUrl = "/img/private_office.jpeg",
					description = "Приватний офіс виконаний в англійському стилі – практичний, стриманий, затишний, багатий. Багато предметів інтер'єру виготовлені з цінних деревних порід, прикрашені традиційною кліткою, квітами, смужкою або пейслі. Колірна гама представлена відтінками благородного дерева, зеленого, бордового та бежевого кольорів. Додатковий комфорт надають високі торшери.",
					services = new List<Service> {
						new Service {name = "Швидкісне Wi-Fi з'єднання" },
						new Service {name = "Закріплене робоче місце" },
						new Service {name = "Доступ до кухні" },
						new Service {name = "Електронна перепустка" },
						new Service {name = "Доступ до зони відпочинку" },
						new Service {name = "Доступ до спортзалу" },
						new Service {name = "Локер" },
						new Service {name = "Гостьовий візит" }
					},
					tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Day"}, pricePerUnit = 300},
						new Tariff { timeUnit = new TimeUnit { name = "Week"}, pricePerUnit = 1500},
						new Tariff { timeUnit = new TimeUnit { name = "Month"}, pricePerUnit = 3000},
					}
				},
				 new Room
				{
					id = 5,
					name = "New York",
					area = 10,
					maxPlaces = 10,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Meeting room")).First(),
					imageUrl = "/img/meeting_room.jpeg",
					description = "Кімната для зустрічей виконана в американському стилі, який поєднує ненав'язливу вишуканість і функціональність. Переважають стримані, але складні бежеві, димчасті та зелені відтінки, у ролі акцентів виступають темні тони. Підлога виконана з темного дерева. У якості меблів виступає масивна з простими формами, яка раціонально використовує кожен метр. У центрі кімнати розташований великих світильників світильник, периметр кімнати доповнений точеними настінними світильниками.",
					services = new List<Service> {
						new Service {name = "Швидкісне Wi-Fi з'єднання" },
						new Service {name = "Фліпчарт" },
						new Service {name = "Принтер/сканер" },
						new Service {name = "Технічне забезпечення" },
						new Service {name = "Технічна підтримка" }
						},
					tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Day"}, pricePerUnit = 250}
					}
				},
				  new Room
				{
					id = 6,
					name = "Rome",
					area = 3,
					maxPlaces = 1,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("Skype room")).First(),
					imageUrl = "/img/skype_room.jpg",
					description = "Кімната для дзвінків виконана в італійському стилі бароко з властивою йому пафосністю, експресивністю, динамізмом та суворою симетрією. В інтер'єрі відчувається рух. Усі поверхні оздоблені деревом, великі вікна оздоблені багатошаровими шторами. Серед декору можна знайти безліч предметів із флористичними принтами. Гарна штучна освітленість реалізується завдяки безлічі настінних світильників.",
					services = new List<Service> {
						new Service {name = "Швидкісне Wi-Fi з'єднання" },
						new Service {name = "Технічне забезпечення" },
						new Service {name = "Технічна підтримка" }
						},
					tariffs = new List<Tariff> {
						new Tariff { timeUnit = new TimeUnit { name = "Day"}, pricePerUnit = 150}
					}
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