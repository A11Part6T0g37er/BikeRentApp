using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentApp.Models
{
    public class BIkeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BikeType BikeType { get; set; }
        public decimal RentPrice { get; set; }
        public bool IsRented { get; set; }
    }
}
