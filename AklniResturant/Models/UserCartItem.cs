namespace AklniResturant.Models
{
    public class UserCartItem
    {
        public int UserCartItemId { get; set; }

        public int UserCartId { get; set; }
        public UserCart UserCart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
