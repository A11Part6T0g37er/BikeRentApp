namespace BikeRentApp.Controller
{
    public class BikeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BikeType BikeType { get; set; }
        public decimal RentPrice { get; set; }
        public bool IsRented { get; set; }
    }
}