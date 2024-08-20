using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelPlaneAPI.Models
{
    public class Plane
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Scale { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ManufactureDate { get; set; }  // New property
        public string Model { get; set; }  // New property
    }
}