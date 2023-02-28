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
                new RoomType {name = "Open space", description = "������� ������ �� ������������� �������� ������"},
                new RoomType {name = "Lounge zone", description = "������� ������ �� �'����� �������� �� ����������� ����������"},
                new RoomType {name = "Private office", description = "��������� ��������� ������ ��� 2-3 ���"},
                new RoomType {name = "Meeting room", description = "ʳ����� ��� ���������� �������� �� ��� ���������� �����������"},
                new RoomType {name = "Skype room", description = "�������� ������ �� ������ ��� ������"},
                new RoomType {name = "Business suite", description = "������� ��������� ������ ��� ������� ������"},
            };
            }
        }
    }
}