using System;
using System.ComponentModel.DataAnnotations;

namespace FullApplication.Models
{
    public class ShoppingCartModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
