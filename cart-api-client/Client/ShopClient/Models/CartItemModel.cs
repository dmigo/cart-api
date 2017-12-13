namespace Client.ShopClient.Models
{
    class CartItemModel
    {
        public ArticleModel Article
        {
            get;
            set;
        }
        public int Quantity { get; set; }
    }
}
