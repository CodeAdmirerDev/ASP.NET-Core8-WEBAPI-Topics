﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoMapperUsageInWebAPI.Models.DTOs
{
    public class CreateProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public decimal Price { get; set; }
        //SerailNumber is like Category-Brand-Model-Year-ProductId
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }

        //Inrernal or confidential data fields be hidden from the customers
        public decimal SupplierPrice { get; set; }
        public string SupplierName { get; set; }
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

    }
}
