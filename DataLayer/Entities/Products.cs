﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Products : BaseEntity
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Pieces { get; private set; }
        public Guid ShoppingCartId { get; set; }

        [NotMapped]
        public double Total { get; private set; }
        public ShoppingCart ShoppingCart { get;  set; }

        public Products(string name, double price, int pieces)
        {
            Name = name;
            Price = price;
            Pieces = pieces;
            Total = ComputeTotal();
        }

        public double ComputeTotal()
        {
            return Pieces * Price;
        }
    }
}
