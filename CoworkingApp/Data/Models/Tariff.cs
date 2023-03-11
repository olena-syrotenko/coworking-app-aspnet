using CoworkingApp.Data.Models.Utils;

namespace CoworkingApp.Data.Models
{
	public class Tariff
	{
		public int id { set; get; }
		public int roomId { set; get; }
		public int timeUnitId { set; get; }
		public TimeUnit timeUnit { set; get; }
		public double pricePerUnit { set; get; }
	}
}
