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
                        new RoomType {name = "Open space", description = "Великий простір із незакріпленими робочими місцями"},
                        new RoomType {name = "Lounge zone", description = "Робочий простір із м'якими диванами та релаксуючою атмосферою"},
                        new RoomType {name = "Private office", description = "Невеликий приватний простір для 2-3 осіб"},
                        new RoomType {name = "Meeting room", description = "Кімната для проведення зустрічей із усім необхідним обладнанням"},
                        new RoomType {name = "Skype room", description = "Приватна кімната на одного для дзвінків"},
                        new RoomType {name = "Business suite", description = "Великий приватний простір для великих команд"}
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
                        new Service {id = 1, name = "Швидкісне Wi-Fi з'єднання" },
                        new Service {id = 2, name = "Незакріплене робоче місце" },
                        new Service {id = 3, name = "Доступ до кухні" },
                        new Service {id = 4, name = "Електронна перепустка" },
                        new Service {id = 5, name = "Доступ до зони відпочинку" },
                        new Service {id = 6, name = "Доступ до спортзалу" },
                        new Service {id = 7, name = "Закріплене робоче місце" },
                        new Service {id = 8, name = "Гостьовий візит" },
                        new Service {id = 9, name = "Послуги юриста" },
                        new Service {id = 10, name = "Технічна підтримка" },
                        new Service {id = 11, name = "Локер" },
                        new Service {id = 12, name = "Фліпчарт" },
                        new Service {id = 13, name = "Принтер/сканер" },
                        new Service {id = 14, name = "Технічне забезпечення" },
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
                            description = "У відкритому робочому просторі панує атмосфера провансу, провінційна романтика, затишок та простота. Вона дозволить забути про міську суєту, досягти спокою та умиротворення. В інтер'єрі використані виключно натуральні матеріали, переважають приглушені зелені, білі, рожеві та бежеві кольори. Серед прикрас можна помітити вінтажні предмети та ковані елементи. З функцією освітлення кімнати ідеально впораються великі люстри та лампи з абажурами з текстилю.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до спортзалу"],
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
                            description = "Лаундж зона виконана в стилі лофт - з мінімумом перегородок, лаконічними формами, великою кількістю світла та повітря, агресивним, «необтесаним» настроєм. Інтер'єр оформлений у холодній кольоровій гамі металіка та різних відтінків сірого. Серед меблів – шкіряні дивани, відкриті полиці та стелажі, журнальні столики. Все це доповнюють велику кількість сучасних освітлювальних приладів, жалюзі на вікнах та картини маловідомих художників.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до зони відпочинку"]
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
                            description = "Бізнес-простір поєднує в собі японську філософію та принципи конструктивізму. Інтер'єр кімнати базується на манімалізмі, чіткій організації простору, функціональності та стриманості. Основна палітра кольорів складається з білих і неяскраво сірих кольорів. Підлога укладена ламінатом світлих деревних тонів. Мінімалістичний інтер'єр органічно доповнений меблями-трансформером та розсувними скляними дверима.",
                            roomType =  RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite.jpg",
                            services = new List<Service> {  
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Закріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до спортзалу"],
                                Services["Локер"],
                                Services["Гостьовий візит"],
                                Services["Послуги юриста"],
                                Services["Технічна підтримка"]
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
                            description = "Приватний офіс виконаний в англійському стилі – практичний, стриманий, затишний, багатий. Багато предметів інтер'єру виготовлені з цінних деревних порід, прикрашені традиційною кліткою, квітами, смужкою або пейслі. Колірна гама представлена відтінками благородного дерева, зеленого, бордового та бежевого кольорів. Додатковий комфорт надають високі торшери.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Закріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до спортзалу"],
                                Services["Локер"],
                                Services["Гостьовий візит"]
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
                            description = "Кімната для зустрічей виконана в американському стилі, який поєднує ненав'язливу вишуканість і функціональність. Переважають стримані, але складні бежеві, димчасті та зелені відтінки, у ролі акцентів виступають темні тони. Підлога виконана з темного дерева. У якості меблів виступає масивна з простими формами, яка раціонально використовує кожен метр. У центрі кімнати розташований великих світильників світильник, периметр кімнати доповнений точеними настінними світильниками.",
                             services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Фліпчарт"],
                                Services["Принтер/сканер"],
                                Services["Технічне забезпечення"],
                                Services["Технічна підтримка"]
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
                            description = "Кімната для дзвінків виконана в італійському стилі бароко з властивою йому пафосністю, експресивністю, динамізмом та суворою симетрією. В інтер'єрі відчувається рух. Усі поверхні оздоблені деревом, великі вікна оздоблені багатошаровими шторами. Серед декору можна знайти безліч предметів із флористичними принтами. Гарна штучна освітленість реалізується завдяки безлічі настінних світильників.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Технічне забезпечення"],
                                Services["Технічна підтримка"]
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
                            description = "Відкритий простір виконаний у скандинавському стилі - природному та легкому. Відрізняється простотою, натуральністю та відсутністю хитромудрих ідей. Чистий, світлий, затишний робочий простір налаштовує на правильний лад завдяки простору, розмаїттю світла та впорядкованості. Інтер'єр виконаний у відтінках білого, з обробкою з натуральних матеріалів. Меблі легкі, прості і комфортні: столи і стільці на тонких ніжках. Компенсувати нестачу природного освітлення допомагають великі вікна та багаторівневе освітлення.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
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
                            description = "Лаундж зона відразу привертає увагу завдяки бохо стилю - вона рясніє яскравими фарбами, химерними предметами, в ній відчуваються свобода, якась легковажність і творчий погляд на навколишній простір. Для роботи таку кімнату часто вибирають розкуті люди, які звикли спокійно самовиражатися і не обмежувати себе ніякими рамками. Жодних загальноприйнятих правил, умовностей, порядку, турбот, це творчий хаос і орієнтація на внутрішній світ, веселощі. Що стосується меблів, вони абсолютно різні: від класичних до сільських і вінтажних. Освітлення тепле та м'яке.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до кухні"],
                            },
                        },
                        new Room
                        {
                            id = 9,
                            name = "Lyon",
                            area = 50,
                            maxPlaces = 10,
                            price = 300,
                            description = "Бізнес простір поєднує атмосферу класицизму - ідеали античного мистецтва, витіюваті форми, дорогий декор і симетричні пропорції. Колірне рішення виконане в трьох кольорах: світлий фон, переливи і яскравий, але не кричучий колір.",
                            roomType = RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite_lyon.jpg",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Локер"],
                                Services["Технічна підтримка"]
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
                            description = "Приватний офіс відрізняється наявністю безлічі зелені в інтер'єрі, де використовуються рослинні мотиви та декорації, а також багато зелені у вигляді живих чи штучних рослин. Він допоможе створити атмосферу тропічного лісу або саду, і підходить для тих, хто хоче додати свіжості та життєвої енергії у свій робочий день.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Закріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до спортзалу"],
                                Services["Локер"],
                                Services["Технічна підтримка"]
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
                            description = "Переговорна кімната виконана у стилі хай-тек, який характеризується використанням сучасних технологій та матеріалів. В інтер'єрі є металеві конструкції, скло, пластик, а також сучасні електронні пристрої та освітлення. Ми пропонуємо сучасний, стильний та функціональний інтер'єр для проведення найважливіших зустрічей.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Технічне забезпечення"],
                                Services["Технічна підтримка"]
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
                            description = "Кімната для дзвінків виконана у найкращих традиціях модерну - спрощені форми, відсутність декору та використання таких матеріалів, таких як скло, метал та пластик. Характерною рисою кімнати є використання простих геометричних форм, абстрактних візерунків та яскравих контрастних кольорів. Меблі мають мінімалістичні форми, гладкі поверхні та металеві деталі.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Технічна підтримка"]
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
                            description = "Відкритий простір виконаний у стилі модерн. Має найбільшу місткість та пропонує зручні дерев'яні столи та ортопедичні крісла для комфортної роботи. Кімната заповнена сонячним світлом завдяки величезним панорамним вікнам, а також передбачене гарне штучне освітлення завдяки підвісним світильникам.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Принтер/сканер"]
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
                            description = "Головною особливістю цієї лаундж зони є незвичайне розташування робочих місць, вони розміщені півколом навколо острівців із великою кількістю зелені. Ви можете вибрати м'які крісла або дерев'яні лави, освітлення розташоване по всьому периметру острівців.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Доступ до зони відпочинку"],
                            },
                        },
                        new Room
                        {
                            id = 15,
                            name = "Chicago",
                            area = 40,
                            maxPlaces = 8,
                            price = 450,
                            description = "Бізнес простір виконаний у світлих спокійних тонах, які розслаблюють та налаштовують на спокійну робочу атмосферу. Додатково кімната обладнана телевізорами для демонстрації презентацій та робочих матеріалів та окремими зонами для невеликих групових обговорень.",
                            roomType = RoomTypes["Business suite"],
                            imageUrl = "/img/business_suite_tech.png",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Закріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Локер"],
                                Services["Технічне забезпечення"],
                                Services["Технічна підтримка"]
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
                            description = "Найменший приватний офіс місткістю лише для двох осіб забезпечить вам максимальну конфіденційність у роботі та позбавить зайвого шуму. Інтер'єр мінімалістичний – у світлих тонах, без нав'язливого декору та з гарним холодним штучним освітленням.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Закріплене робоче місце"],
                                Services["Доступ до кухні"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Локер"],
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
                            description = "Незвичайна переговорна кімната в стилі еклектики підкорить вас своєю невимушеністю та розслабленим інтер'єром. Багатоколірне рішення в оформленні та м'які зручні дивани налаштують вас на позитивний лад та плідну роботу.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],

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
                            description = "Невелика кімната для дзвінків обладнана всім необхідним для комфортної роботи: столом, висоту якого можна регулювати, зручним кріслом та точковим освітленням. Інтер'єр представлений у біло-чорних сучасних відтінках з великими прозорими стінами, а стіни прикрашені своєрідними графіті.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Доступ до кухні"]
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
                            description = "Невеликий відкритий простір в індустріальному стилі ідеально підійде для тих, хто знаходить натхнення в унікальному та нетрадиційному дизайні. Грубуватий вигляд інтер'єру з використанням необроблених матеріалів та сірих відтінків дозволить відчути поєднання сучасності та промисловості.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Електронна перепустка"],
                                Services["Доступ до зони відпочинку"]
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
                            description = "Кімната для зустрічей виконана у стриманому класичному стилі та обладнана всім необхідним для проведення ділових зустрічей: технічне обладнання для демонстрації матеріалів, великий загальний стіл, зручні крісла та панорамні вікна, які заливають кімнату великою кількістю світла. На всьому периметрі кімнати розташовані додаткові точкові джерела штучного світла. Серед прикрас – зелень та килими, що доповнюють атмосферу стриманістю та діловитістю.",
                            services = new List<Service> {
                                Services["Швидкісне Wi-Fi з'єднання"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Технічне забезпечення"],
                                Services["Доступ до кухні"],
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