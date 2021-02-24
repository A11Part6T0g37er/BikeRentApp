using BikeRentApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BikeRentApp.Models
{
    public class BikeRepository : GenericRepository<Bike>, IBikeRepository
    {


        public BikeRepository(BikeContext context) : base(context)
        {

        }


        public IEnumerable<Bike> GetAllNonRentedBikes()
        {

            return BikeContext.Bikes.Include(x => x.IsRented == false);

        }

        public IEnumerable<Bike> GetAllRentedBikes()
        {
            return BikeContext.Bikes.Include(x => x.IsRented == true);
        }

        public BikeContext BikeContext
        {
            get { return Context as BikeContext; }
        }

        internal async Task<Bike> FindAsync(long id)
        {
            return await BikeContext.Bikes.FindAsync(id);
        }
    }
}