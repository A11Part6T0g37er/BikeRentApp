using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;



namespace BikeRentApp.Models.DAL
{
    public class BikeContext : System.Data.Entity.DbContext
    {
        public BikeContext()
            : base("name=BikeContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual System.Data.Entity.DbSet<Bike> Bikes { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BikesConfiguration());
        }
    }
}
