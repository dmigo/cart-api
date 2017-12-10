using Api.Models;
using Cart;
using System.Linq;

namespace Api.Mappers
{
    public static class ModelExtensions
    {
        public static CartModel ToModel(this Cart.Cart cart)
        {
            return new CartModel
            {
                Items = cart?.Items.Select(
                    item => item.ToModel()
                )
            };
        }
        public static CartItemModel ToModel(this CartItem item)
        {
            return new CartItemModel
            {
                Article = new ArticleShortModel { Id = item.ArticleId },
                Quantity = item.Quantity,
            };
        }
        
        public static Cart.Cart ToDomain(this CartModel model)
        {
            return new Cart.Cart
            {
                Items = model.Items.Select(
                    item => item.ToDomain()
                )
            };
        }
        public static CartItem ToDomain(this CartItemModel item)
        {
            return new CartItem
            {
                ArticleId = item.Article.Id,
                Quantity = item.Quantity,
            };
        }
    }
}