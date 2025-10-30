using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AklniResturant.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdIngredients",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdIngredients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ProdIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Egyptian Dishes" },
                    { 2, "Grilled" },
                    { 3, "Seafood" },
                    { 4, "Sandwiches" },
                    { 5, "Salads" },
                    { 6, "Drinks" },
                    { 7, "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 1, "Rice" },
                    { 2, "Lentils" },
                    { 3, "Pasta" },
                    { 4, "Tomato Sauce" },
                    { 5, "Fried Onions" },
                    { 6, "Garlic" },
                    { 7, "Chili Pepper" },
                    { 8, "Cumin" },
                    { 9, "Coriander" },
                    { 10, "Beef" },
                    { 11, "Chicken" },
                    { 12, "Kebda" },
                    { 13, "Sogo2" },
                    { 14, "Molokhia Leaves" },
                    { 15, "Bamia" },
                    { 16, "Fish Fillet" },
                    { 17, "Shrimp" },
                    { 18, "Tahina" },
                    { 19, "Chickpeas" },
                    { 20, "Ful" },
                    { 21, "Parsley" },
                    { 22, "Lemon Juice" },
                    { 23, "Olive Oil" },
                    { 24, "Flour" },
                    { 25, "Sugar" },
                    { 26, "Milk" },
                    { 27, "Nuts (Pistachio, Almond, Walnut)" },
                    { 28, "Butter or Ghee" },
                    { 29, "Honey or Syrup" },
                    { 30, "Mint Leaves" },
                    { 31, "Tea Leaves" },
                    { 32, "Coffee Beans" },
                    { 33, "Mango" },
                    { 34, "Guava" },
                    { 35, "Strawberry" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Traditional Egyptian mix of rice, lentils, pasta, tomato sauce, and fried onions.", "Koshary", 45.0, 30 },
                    { 2, 1, "Rich green molokhia soup served with rice and roasted chicken.", "Molokhia with Chicken", 70.0, 25 },
                    { 3, 1, "Okra stew cooked with tender beef cubes and tomato sauce.", "Bamia with Meat", 80.0, 20 },
                    { 4, 1, "Layers of crispy bread, rice, and meat topped with garlic tomato sauce.", "Fattah", 90.0, 15 },
                    { 5, 1, "Classic Egyptian fava beans with olive oil, cumin, and lemon.", "Ful Medames", 25.0, 40 },
                    { 6, 2, "Juicy minced beef skewers grilled to perfection.", "Grilled Kofta", 85.0, 25 },
                    { 7, 2, "Charcoal-grilled marinated chicken served with salad and tahina.", "Grilled Chicken", 95.0, 20 },
                    { 8, 2, "Alexandrian-style liver sautéed with garlic and chili.", "Liver (Kebda Eskandarani)", 70.0, 18 },
                    { 9, 2, "Spicy grilled Egyptian sausages with garlic and cumin.", "Grilled Sogo2", 75.0, 18 },
                    { 10, 3, "Crispy fried fish fillet served with rice and tahina sauce.", "Fried Fish Fillet", 110.0, 15 },
                    { 11, 3, "Fresh shrimp grilled with lemon, garlic, and olive oil.", "Grilled Shrimp", 140.0, 12 },
                    { 12, 3, "Basmati rice cooked with mixed seafood and herbs.", "Seafood Rice", 130.0, 10 },
                    { 13, 4, "Spicy liver sandwich with tahina and pickles.", "Kebda Sandwich", 35.0, 30 },
                    { 14, 4, "Egyptian sausage sandwich with chili and garlic.", "Sogo2 Sandwich", 40.0, 30 },
                    { 15, 4, "Tender beef or chicken shawarma wrapped in pita with garlic sauce.", "Shawarma Sandwich", 50.0, 25 },
                    { 16, 4, "Deep-fried chickpea balls with tahina and salad in pita bread.", "Falafel Sandwich", 30.0, 35 },
                    { 17, 5, "Creamy tahina dip flavored with lemon and garlic.", "Tahina Salad", 15.0, 50 },
                    { 18, 5, "Egyptian-style salad with tomatoes, cucumbers, onions, and parsley.", "Baladi Salad", 20.0, 40 },
                    { 19, 5, "Healthy chickpea salad with olive oil and lemon dressing.", "Chickpea Salad", 25.0, 30 },
                    { 20, 6, "Refreshing black tea infused with fresh mint leaves.", "Mint Tea", 20.0, 50 },
                    { 21, 6, "Strong traditional coffee served in a small cup.", "Turkish Coffee", 25.0, 40 },
                    { 22, 6, "Freshly blended mango juice made from ripe mangoes.", "Mango Juice", 30.0, 35 },
                    { 23, 6, "Thick and sweet guava juice served cold.", "Guava Juice", 30.0, 35 },
                    { 24, 6, "Creamy strawberry smoothie with milk and honey.", "Strawberry Smoothie", 35.0, 25 },
                    { 25, 7, "Sweet semolina cake soaked in syrup and topped with nuts.", "Basbousa", 25.0, 30 },
                    { 26, 7, "Layers of pastry filled with nuts and honey syrup.", "Baklava", 35.0, 25 },
                    { 27, 7, "Creamy rice pudding with milk and cinnamon.", "Rice Pudding", 30.0, 20 },
                    { 28, 7, "Traditional Egyptian dessert made with puff pastry, milk, and nuts.", "Om Ali", 40.0, 18 }
                });

            migrationBuilder.InsertData(
                table: "ProdIngredients",
                columns: new[] { "IngredientId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 8, 1 },
                    { 1, 2 },
                    { 6, 2 },
                    { 11, 2 },
                    { 14, 2 },
                    { 22, 2 },
                    { 4, 3 },
                    { 6, 3 },
                    { 8, 3 },
                    { 10, 3 },
                    { 15, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 6, 4 },
                    { 10, 4 },
                    { 8, 5 },
                    { 20, 5 },
                    { 22, 5 },
                    { 23, 5 },
                    { 6, 6 },
                    { 8, 6 },
                    { 9, 6 },
                    { 10, 6 },
                    { 11, 7 },
                    { 18, 7 },
                    { 21, 7 },
                    { 22, 7 },
                    { 6, 8 },
                    { 7, 8 },
                    { 12, 8 },
                    { 6, 9 },
                    { 7, 9 },
                    { 8, 9 },
                    { 13, 9 },
                    { 16, 10 },
                    { 18, 10 },
                    { 22, 10 },
                    { 23, 10 },
                    { 6, 11 },
                    { 17, 11 },
                    { 22, 11 },
                    { 23, 11 },
                    { 1, 12 },
                    { 16, 12 },
                    { 17, 12 },
                    { 21, 12 },
                    { 23, 12 },
                    { 7, 13 },
                    { 12, 13 },
                    { 18, 13 },
                    { 6, 14 },
                    { 7, 14 },
                    { 13, 14 },
                    { 6, 15 },
                    { 10, 15 },
                    { 11, 15 },
                    { 18, 15 },
                    { 18, 16 },
                    { 19, 16 },
                    { 21, 16 },
                    { 6, 17 },
                    { 18, 17 },
                    { 22, 17 },
                    { 21, 18 },
                    { 22, 18 },
                    { 23, 18 },
                    { 19, 19 },
                    { 21, 19 },
                    { 22, 19 },
                    { 23, 19 },
                    { 30, 20 },
                    { 31, 20 },
                    { 32, 21 },
                    { 26, 22 },
                    { 29, 22 },
                    { 33, 22 },
                    { 26, 23 },
                    { 34, 23 },
                    { 26, 24 },
                    { 29, 24 },
                    { 35, 24 },
                    { 24, 25 },
                    { 25, 25 },
                    { 27, 25 },
                    { 29, 25 },
                    { 24, 26 },
                    { 27, 26 },
                    { 28, 26 },
                    { 29, 26 },
                    { 1, 27 },
                    { 25, 27 },
                    { 26, 27 },
                    { 24, 28 },
                    { 26, 28 },
                    { 27, 28 },
                    { 28, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdIngredients_IngredientId",
                table: "ProdIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProdIngredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
