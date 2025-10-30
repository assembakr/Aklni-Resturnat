using Microsoft.AspNetCore.Identity;

namespace AklniResturant.Models
{
    public class User: IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }

    }
}
