namespace AklniResturant.Models
{
    public class UserCart
    {
        public int UserCartId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<UserCartItem> Items { get; set; } = new List<UserCartItem>();
    }
}
