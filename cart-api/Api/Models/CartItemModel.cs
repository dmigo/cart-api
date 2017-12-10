using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CartItemModel
    {
        [Required]
        public ArticleShortModel Article { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}