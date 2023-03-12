namespace CoworkingApp.Data.Models
{
    public class Place
    {
        public int id { get; set; }
        public string code { get; set; }
        public int roomId { get; set; }
        public Room room { get; set; }
    }
}