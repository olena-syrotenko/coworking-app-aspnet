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
				new RoomType {name = "open space", description = "������� ������ �� ������������� �������� ������"},
				new RoomType {name = "lounge zone", description = "������� ������ �� �'����� �������� �� ����������� ����������"},
				new RoomType {name = "private office", description = "��������� ��������� ������ ��� 2-3 ���"},
				new RoomType {name = "meeting room", description = "ʳ����� ��� ���������� �������� �� ��� ���������� �����������"},
				new RoomType {name = "skype room", description = "�������� ������ �� ������ ��� ������"},
				new RoomType {name = "business suite", description = "������� ��������� ������ ��� ������� ������"},
			};
			}
		}
	}
}