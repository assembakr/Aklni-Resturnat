using AklniResturant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AklniResturant.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProdIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(pi => pi.ProdIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProdIngredients)
                .HasForeignKey(i => i.IngredientId);

            // seeding data
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Egyptian Dishes"},
                new Category { CategoryId = 2, Name = "Grilled" },
                new Category { CategoryId = 3, Name = "Seafood" },
                new Category { CategoryId = 4, Name = "Sandwiches" },
                new Category { CategoryId = 5, Name = "Salads" },
                new Category { CategoryId = 6, Name = "Drinks" },
                new Category { CategoryId = 7, Name = "Desserts" }
                );

            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Rice" },
                new Ingredient { IngredientId = 2, Name = "Lentils" },
                new Ingredient { IngredientId = 3, Name = "Pasta" },
                new Ingredient { IngredientId = 4, Name = "Tomato Sauce" },
                new Ingredient { IngredientId = 5, Name = "Fried Onions" },
                new Ingredient { IngredientId = 6, Name = "Garlic" },
                new Ingredient { IngredientId = 7, Name = "Chili Pepper" },
                new Ingredient { IngredientId = 8, Name = "Cumin" },
                new Ingredient { IngredientId = 9, Name = "Coriander" },
                new Ingredient { IngredientId = 10, Name = "Beef" },
                new Ingredient { IngredientId = 11, Name = "Chicken" },
                new Ingredient { IngredientId = 12, Name = "Kebda" },
                new Ingredient { IngredientId = 13, Name = "Sogo2" },
                new Ingredient { IngredientId = 14, Name = "Molokhia Leaves" },
                new Ingredient { IngredientId = 15, Name = "Bamia" },
                new Ingredient { IngredientId = 16, Name = "Fish Fillet" },
                new Ingredient { IngredientId = 17, Name = "Shrimp" },
                new Ingredient { IngredientId = 18, Name = "Tahina" },
                new Ingredient { IngredientId = 19, Name = "Chickpeas" },
                new Ingredient { IngredientId = 20, Name = "Ful" },
                new Ingredient { IngredientId = 21, Name = "Parsley" },
                new Ingredient { IngredientId = 22, Name = "Lemon Juice" },
                new Ingredient { IngredientId = 23, Name = "Olive Oil" },
                new Ingredient { IngredientId = 24, Name = "Flour" },
                new Ingredient { IngredientId = 25, Name = "Sugar" },
                new Ingredient { IngredientId = 26, Name = "Milk" },
                new Ingredient { IngredientId = 27, Name = "Nuts (Pistachio, Almond, Walnut)" },
                new Ingredient { IngredientId = 28, Name = "Butter or Ghee" },
                new Ingredient { IngredientId = 29, Name = "Honey or Syrup" },
                new Ingredient { IngredientId = 30, Name = "Mint Leaves" },
                new Ingredient { IngredientId = 31, Name = "Tea Leaves" },
                new Ingredient { IngredientId = 32, Name = "Coffee Beans" },
                new Ingredient { IngredientId = 33, Name = "Mango" },
                new Ingredient { IngredientId = 34, Name = "Guava" },
                new Ingredient { IngredientId = 35, Name = "Strawberry" }
                );

            builder.Entity<Product>().HasData(
            // 🥘 Egyptian Dishes
            new Product { ProductId = 1, Name = "Koshary", Description = "Traditional Egyptian mix of rice, lentils, pasta, tomato sauce, and fried onions.", Price = 45, Stock = 30, CategoryId = 1 },
            new Product { ProductId = 2, Name = "Molokhia with Chicken", Description = "Rich green molokhia soup served with rice and roasted chicken.", Price = 70, Stock = 25, CategoryId = 1 },
            new Product { ProductId = 3, Name = "Bamia with Meat", Description = "Okra stew cooked with tender beef cubes and tomato sauce.", Price = 80, Stock = 20, CategoryId = 1 },
            new Product { ProductId = 4, Name = "Fattah", Description = "Layers of crispy bread, rice, and meat topped with garlic tomato sauce.", Price = 90, Stock = 15, CategoryId = 1 },
            new Product { ProductId = 5, Name = "Ful Medames", Description = "Classic Egyptian fava beans with olive oil, cumin, and lemon.", Price = 25, Stock = 40, CategoryId = 1 },

            // 🍖 Grilled
            new Product { ProductId = 6, Name = "Grilled Kofta", Description = "Juicy minced beef skewers grilled to perfection.", Price = 85, Stock = 25, CategoryId = 2 },
            new Product { ProductId = 7, Name = "Grilled Chicken", Description = "Charcoal-grilled marinated chicken served with salad and tahina.", Price = 95, Stock = 20, CategoryId = 2 },
            new Product { ProductId = 8, Name = "Liver (Kebda Eskandarani)", Description = "Alexandrian-style liver sautéed with garlic and chili.", Price = 70, Stock = 18, CategoryId = 2 },
            new Product { ProductId = 9, Name = "Grilled Sogo2", Description = "Spicy grilled Egyptian sausages with garlic and cumin.", Price = 75, Stock = 18, CategoryId = 2 },

            // 🐟 Seafood
            new Product { ProductId = 10, Name = "Fried Fish Fillet", Description = "Crispy fried fish fillet served with rice and tahina sauce.", Price = 110, Stock = 15, CategoryId = 3 },
            new Product { ProductId = 11, Name = "Grilled Shrimp", Description = "Fresh shrimp grilled with lemon, garlic, and olive oil.", Price = 140, Stock = 12, CategoryId = 3 },
            new Product { ProductId = 12, Name = "Seafood Rice", Description = "Basmati rice cooked with mixed seafood and herbs.", Price = 130, Stock = 10, CategoryId = 3 },

            // 🥪 Sandwiches
            new Product { ProductId = 13, Name = "Kebda Sandwich", Description = "Spicy liver sandwich with tahina and pickles.", Price = 35, Stock = 30, CategoryId = 4 },
            new Product { ProductId = 14, Name = "Sogo2 Sandwich", Description = "Egyptian sausage sandwich with chili and garlic.", Price = 40, Stock = 30, CategoryId = 4 },
            new Product { ProductId = 15, Name = "Shawarma Sandwich", Description = "Tender beef or chicken shawarma wrapped in pita with garlic sauce.", Price = 50, Stock = 25, CategoryId = 4 },
            new Product { ProductId = 16, Name = "Falafel Sandwich", Description = "Deep-fried chickpea balls with tahina and salad in pita bread.", Price = 30, Stock = 35, CategoryId = 4 },

            // 🥗 Salads
            new Product { ProductId = 17, Name = "Tahina Salad", Description = "Creamy tahina dip flavored with lemon and garlic.", Price = 15, Stock = 50, CategoryId = 5 },
            new Product { ProductId = 18, Name = "Baladi Salad", Description = "Egyptian-style salad with tomatoes, cucumbers, onions, and parsley.", Price = 20, Stock = 40, CategoryId = 5 },
            new Product { ProductId = 19, Name = "Chickpea Salad", Description = "Healthy chickpea salad with olive oil and lemon dressing.", Price = 25, Stock = 30, CategoryId = 5 },

            // 🍹 Drinks
            new Product { ProductId = 20, Name = "Mint Tea", Description = "Refreshing black tea infused with fresh mint leaves.", Price = 20, Stock = 50, CategoryId = 6 },
            new Product { ProductId = 21, Name = "Turkish Coffee", Description = "Strong traditional coffee served in a small cup.", Price = 25, Stock = 40, CategoryId = 6 },
            new Product { ProductId = 22, Name = "Mango Juice", Description = "Freshly blended mango juice made from ripe mangoes.", Price = 30, Stock = 35, CategoryId = 6 },
            new Product { ProductId = 23, Name = "Guava Juice", Description = "Thick and sweet guava juice served cold.", Price = 30, Stock = 35, CategoryId = 6 },
            new Product { ProductId = 24, Name = "Strawberry Smoothie", Description = "Creamy strawberry smoothie with milk and honey.", Price = 35, Stock = 25, CategoryId = 6 },

            // 🍰 Desserts
            new Product { ProductId = 25, Name = "Basbousa", Description = "Sweet semolina cake soaked in syrup and topped with nuts.", Price = 25, Stock = 30, CategoryId = 7 },
            new Product { ProductId = 26, Name = "Baklava", Description = "Layers of pastry filled with nuts and honey syrup.", Price = 35, Stock = 25, CategoryId = 7 },
            new Product { ProductId = 27, Name = "Rice Pudding", Description = "Creamy rice pudding with milk and cinnamon.", Price = 30, Stock = 20, CategoryId = 7 },
            new Product { ProductId = 28, Name = "Om Ali", Description = "Traditional Egyptian dessert made with puff pastry, milk, and nuts.", Price = 40, Stock = 18, CategoryId = 7 }
            );

            builder.Entity<ProductIngredient>().HasData(
    // 🥘 Egyptian Dishes
    new ProductIngredient { ProductId = 1, IngredientId = 1 }, // Rice
    new ProductIngredient { ProductId = 1, IngredientId = 2 }, // Lentils
    new ProductIngredient { ProductId = 1, IngredientId = 3 }, // Pasta
    new ProductIngredient { ProductId = 1, IngredientId = 4 }, // Tomato Sauce
    new ProductIngredient { ProductId = 1, IngredientId = 5 }, // Fried Onions
    new ProductIngredient { ProductId = 1, IngredientId = 8 }, // Cumin

    new ProductIngredient { ProductId = 2, IngredientId = 14 }, // Molokhia Leaves
    new ProductIngredient { ProductId = 2, IngredientId = 11 }, // Chicken
    new ProductIngredient { ProductId = 2, IngredientId = 1 }, // Rice
    new ProductIngredient { ProductId = 2, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 2, IngredientId = 22 }, // Lemon Juice

    new ProductIngredient { ProductId = 3, IngredientId = 15 }, // Bamia
    new ProductIngredient { ProductId = 3, IngredientId = 10 }, // Beef
    new ProductIngredient { ProductId = 3, IngredientId = 4 }, // Tomato Sauce
    new ProductIngredient { ProductId = 3, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 3, IngredientId = 8 }, // Cumin

    new ProductIngredient { ProductId = 4, IngredientId = 1 }, // Rice
    new ProductIngredient { ProductId = 4, IngredientId = 10 }, // Beef
    new ProductIngredient { ProductId = 4, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 4, IngredientId = 4 }, // Tomato Sauce

    new ProductIngredient { ProductId = 5, IngredientId = 20 }, // Ful
    new ProductIngredient { ProductId = 5, IngredientId = 8 }, // Cumin
    new ProductIngredient { ProductId = 5, IngredientId = 22 }, // Lemon Juice
    new ProductIngredient { ProductId = 5, IngredientId = 23 }, // Olive Oil

    // 🍖 Grilled
    new ProductIngredient { ProductId = 6, IngredientId = 10 }, // Beef
    new ProductIngredient { ProductId = 6, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 6, IngredientId = 8 }, // Cumin
    new ProductIngredient { ProductId = 6, IngredientId = 9 }, // Coriander

    new ProductIngredient { ProductId = 7, IngredientId = 11 }, // Chicken
    new ProductIngredient { ProductId = 7, IngredientId = 18 }, // Tahina
    new ProductIngredient { ProductId = 7, IngredientId = 21 }, // Parsley
    new ProductIngredient { ProductId = 7, IngredientId = 22 }, // Lemon Juice

    new ProductIngredient { ProductId = 8, IngredientId = 12 }, // Kebda
    new ProductIngredient { ProductId = 8, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 8, IngredientId = 7 }, // Chili Pepper

    new ProductIngredient { ProductId = 9, IngredientId = 13 }, // Sogo2
    new ProductIngredient { ProductId = 9, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 9, IngredientId = 7 }, // Chili Pepper
    new ProductIngredient { ProductId = 9, IngredientId = 8 }, // Cumin

    // 🐟 Seafood
    new ProductIngredient { ProductId = 10, IngredientId = 16 }, // Fish Fillet
    new ProductIngredient { ProductId = 10, IngredientId = 18 }, // Tahina
    new ProductIngredient { ProductId = 10, IngredientId = 22 }, // Lemon Juice
    new ProductIngredient { ProductId = 10, IngredientId = 23 }, // Olive Oil

    new ProductIngredient { ProductId = 11, IngredientId = 17 }, // Shrimp
    new ProductIngredient { ProductId = 11, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 11, IngredientId = 22 }, // Lemon Juice
    new ProductIngredient { ProductId = 11, IngredientId = 23 }, // Olive Oil

    new ProductIngredient { ProductId = 12, IngredientId = 16 }, // Fish Fillet
    new ProductIngredient { ProductId = 12, IngredientId = 17 }, // Shrimp
    new ProductIngredient { ProductId = 12, IngredientId = 1 }, // Rice
    new ProductIngredient { ProductId = 12, IngredientId = 21 }, // Parsley
    new ProductIngredient { ProductId = 12, IngredientId = 23 }, // Olive Oil

    // 🥪 Sandwiches
    new ProductIngredient { ProductId = 13, IngredientId = 12 }, // Kebda
    new ProductIngredient { ProductId = 13, IngredientId = 18 }, // Tahina
    new ProductIngredient { ProductId = 13, IngredientId = 7 }, // Chili Pepper

    new ProductIngredient { ProductId = 14, IngredientId = 13 }, // Sogo2
    new ProductIngredient { ProductId = 14, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 14, IngredientId = 7 }, // Chili Pepper

    new ProductIngredient { ProductId = 15, IngredientId = 10 }, // Beef
    new ProductIngredient { ProductId = 15, IngredientId = 11 }, // Chicken
    new ProductIngredient { ProductId = 15, IngredientId = 6 }, // Garlic
    new ProductIngredient { ProductId = 15, IngredientId = 18 }, // Tahina

    new ProductIngredient { ProductId = 16, IngredientId = 19 }, // Chickpeas
    new ProductIngredient { ProductId = 16, IngredientId = 18 }, // Tahina
    new ProductIngredient { ProductId = 16, IngredientId = 21 }, // Parsley

    // 🥗 Salads
    new ProductIngredient { ProductId = 17, IngredientId = 18 }, // Tahina
    new ProductIngredient { ProductId = 17, IngredientId = 22 }, // Lemon Juice
    new ProductIngredient { ProductId = 17, IngredientId = 6 }, // Garlic

    new ProductIngredient { ProductId = 18, IngredientId = 21 }, // Parsley
    new ProductIngredient { ProductId = 18, IngredientId = 23 }, // Olive Oil
    new ProductIngredient { ProductId = 18, IngredientId = 22 }, // Lemon Juice

    new ProductIngredient { ProductId = 19, IngredientId = 19 }, // Chickpeas
    new ProductIngredient { ProductId = 19, IngredientId = 21 }, // Parsley
    new ProductIngredient { ProductId = 19, IngredientId = 23 }, // Olive Oil
    new ProductIngredient { ProductId = 19, IngredientId = 22 }, // Lemon Juice

    // 🍹 Drinks
    new ProductIngredient { ProductId = 20, IngredientId = 31 }, // Tea Leaves
    new ProductIngredient { ProductId = 20, IngredientId = 30 }, // Mint Leaves

    new ProductIngredient { ProductId = 21, IngredientId = 32 }, // Coffee Beans

    new ProductIngredient { ProductId = 22, IngredientId = 33 }, // Mango
    new ProductIngredient { ProductId = 22, IngredientId = 26 }, // Milk
    new ProductIngredient { ProductId = 22, IngredientId = 29 }, // Honey or Syrup

    new ProductIngredient { ProductId = 23, IngredientId = 34 }, // Guava
    new ProductIngredient { ProductId = 23, IngredientId = 26 }, // Milk

    new ProductIngredient { ProductId = 24, IngredientId = 35 }, // Strawberry
    new ProductIngredient { ProductId = 24, IngredientId = 26 }, // Milk
    new ProductIngredient { ProductId = 24, IngredientId = 29 }, // Honey or Syrup

    // 🍰 Desserts
    new ProductIngredient { ProductId = 25, IngredientId = 24 }, // Flour
    new ProductIngredient { ProductId = 25, IngredientId = 25 }, // Sugar
    new ProductIngredient { ProductId = 25, IngredientId = 29 }, // Honey or Syrup
    new ProductIngredient { ProductId = 25, IngredientId = 27 }, // Nuts

    new ProductIngredient { ProductId = 26, IngredientId = 24 }, // Flour
    new ProductIngredient { ProductId = 26, IngredientId = 27 }, // Nuts
    new ProductIngredient { ProductId = 26, IngredientId = 29 }, // Honey or Syrup
    new ProductIngredient { ProductId = 26, IngredientId = 28 }, // Butter or Ghee

    new ProductIngredient { ProductId = 27, IngredientId = 1 }, // Rice
    new ProductIngredient { ProductId = 27, IngredientId = 26 }, // Milk
    new ProductIngredient { ProductId = 27, IngredientId = 25 }, // Sugar

    new ProductIngredient { ProductId = 28, IngredientId = 24 }, // Flour (pastry base)
    new ProductIngredient { ProductId = 28, IngredientId = 26 }, // Milk
    new ProductIngredient { ProductId = 28, IngredientId = 27 }, // Nuts
    new ProductIngredient { ProductId = 28, IngredientId = 28 }  // Butter or Ghee
);


        }
    }
}
