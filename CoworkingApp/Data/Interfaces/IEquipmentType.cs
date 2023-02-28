using CoworkingApp.Data.Models;
using System.Collections.Generic;

namespace CoworkingApp.Data.Interfaces
{
	public interface IEquipmentType
	{
		IEnumerable<EquipmentType> AllEquipmentTypes { get; }
	}
}