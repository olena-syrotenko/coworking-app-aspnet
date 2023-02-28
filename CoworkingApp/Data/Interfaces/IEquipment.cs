using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IEquipment
	{
		IEnumerable<Equipment> AllEquipment { get; }
		Equipment getById(int id);
	}
}