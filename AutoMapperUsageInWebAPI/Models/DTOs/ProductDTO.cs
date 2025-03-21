﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoMapperUsageInWebAPI.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        //Renamed the fields to make it more user friendly
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        //SerailNumber is like Category-Brand-Model-Year-ProductId
        public string SerialNumber { get; set; } //ELE-DELL-Laptop-2025-001
        public bool IsActive { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public DateTime CreatedDateTime { get; set; }

        //Confidential data fields are intentionally omitted from the response
    }
}
