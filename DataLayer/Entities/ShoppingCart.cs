using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        [NotMapped]
        public double Total { get; private set; }
        public List<Products> Products { get; private set; }

        public ShoppingCart(DateTime date, string description)
        {
            Date = date;
            Description = description;
            Products = new List<Products>();
            Total = ComputeTotal();
        }

        public double ComputeTotal()
        {
            double result = 0;

            foreach (Products p in Products)
                result += p.Total;

            return result;
        }

        public void AddProduct(Products p)
        {
            Products.Add(p);
        }
    }
}
