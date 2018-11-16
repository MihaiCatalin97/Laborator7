using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullApplication.Models
{
    public class ProductsModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Pieces { get; set; }

        [Required]
        public Guid ShoppingCartId { get; set; }
    }
}
