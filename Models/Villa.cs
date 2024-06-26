﻿using System.ComponentModel.DataAnnotations;

namespace ApiVilla.Models
{
    public class Villa
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public int Sqft { get; set; }
        
        public int Occupancy { get; set; }

        public  string ImageUrl { get; set; }



    }
}
