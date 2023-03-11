using System.Collections.Generic;

namespace CoworkingApp.Data.Models
{
    public class TimeUnit
    {
        public int id { set; get; }
        public string name { set; get; }
        public List<Tariff> tariffs { set; get; }
    }
}
