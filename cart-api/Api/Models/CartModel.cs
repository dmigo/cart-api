using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Cart;

namespace Api.Models
{
    public class CartModel 
    {
        [Required]
        public IEnumerable<CartItemModel> Items { get; set; }
    }
}