using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ModelPlaneAPI.Data
{
    public class PlaneContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }

        public PlaneContext(DbContextOptions<PlaneContext> options) 
        : base(options) 
        {
              
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // If you have specific configurations for Plane, you can add them here
            modelBuilder.Entity<Plane>().ToTable("Planes");
        }

        
    }
}