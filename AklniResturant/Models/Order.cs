namespace AklniResturant.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? UserId { get; set; }

        public User User { get; set; }

        public Decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrdersItems { get; set;}
    }
}
