using System;
using System.Collections.Generic;

namespace CoworkingApp.Data.Models
{
    public class RentApplication
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public double totalPrice { get; set; }
        public DateTime createTime { get; set; }
        public List<RentApplicationDetail> rentDetails { get; set; }
    }
}