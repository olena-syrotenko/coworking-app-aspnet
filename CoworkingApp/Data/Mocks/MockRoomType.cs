using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Mocks
{
    public class MockRoomType : IRoomType
    {
        public IEnumerable<RoomType> AllRoomTypes
        {
            get
            {
                return new List<RoomType>
            {
                new RoomType {name = "Open space", description = "Великий простір із незакріпленими робочими місцями"},
                new RoomType {name = "Lounge zone", description = "Робочий простір із м'якими диванами та релаксуючою атмосферою"},
                new RoomType {name = "Private office", description = "Невеликий приватний простір для 2-3 осіб"},
                new RoomType {name = "Meeting room", description = "Кімната для проведення зустрічей із усім необхідним обладнанням"},
                new RoomType {name = "Skype room", description = "Приватна кімната на одного для дзвінків"},
                new RoomType {name = "Business suite", description = "Великий приватний простір для великих команд"},
            };
            }
        }
    }
}