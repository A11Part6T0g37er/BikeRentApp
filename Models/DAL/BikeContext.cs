using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;



namespace BikeRentApp.Models.DAL
{
    public class BikeContext : DbContext
    {

        public BikeContext() {  Database.EnsureCreated();}
        public BikeContext(DbContextOptions<BikeContext> options)
            :base(options)
        {
           
           
        }

        public virtual DbSet<Bike> Bikes { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bikerentappdb;Trusted_Connection=True;");
            }
        }


    }
}
