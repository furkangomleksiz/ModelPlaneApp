using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Models;

namespace ModelPlaneAPI.Data
{
    public class PlaneContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }

        public PlaneContext(DbContextOptions<PlaneContext> options) 
        : base(options) 
        {  
        }

        
    }
}