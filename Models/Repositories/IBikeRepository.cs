using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentApp.Models.DAL
{
 public   interface IBikeRepository :IRepository<Bike>
    {
     public   IEnumerable<Bike> GetAllRentedBikes();
      public  IEnumerable<Bike> GetAllNonRentedBikes();
    }
}
