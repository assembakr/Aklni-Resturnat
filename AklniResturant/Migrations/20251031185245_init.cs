using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AklniResturant.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ProductIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdIngredients", x => x.ProductIngredientId);
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
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Traditional Egyptian mix of rice, lentils, pasta, tomato sauce, and fried onions.", "", "Koshary", 45.0, 30 },
                    { 2, 1, "Rich green molokhia soup served with rice and roasted chicken.", "", "Molokhia with Chicken", 70.0, 25 },
                    { 3, 1, "Okra stew cooked with tender beef cubes and tomato sauce.", "", "Bamia with Meat", 80.0, 20 },
                    { 4, 1, "Layers of crispy bread, rice, and meat topped with garlic tomato sauce.", "", "Fattah", 90.0, 15 },
                    { 5, 1, "Classic Egyptian fava beans with olive oil, cumin, and lemon.", "", "Ful Medames", 25.0, 40 },
                    { 6, 2, "Juicy minced beef skewers grilled to perfection.", "", "Grilled Kofta", 85.0, 25 },
                    { 7, 2, "Charcoal-grilled marinated chicken served with salad and tahina.", "", "Grilled Chicken", 95.0, 20 },
                    { 8, 2, "Alexandrian-style liver sautéed with garlic and chili.", "", "Liver (Kebda Eskandarani)", 70.0, 18 },
                    { 9, 2, "Spicy grilled Egyptian sausages with garlic and cumin.", "", "Grilled Sogo2", 75.0, 18 },
                    { 10, 3, "Crispy fried fish fillet served with rice and tahina sauce.", "", "Fried Fish Fillet", 110.0, 15 },
                    { 11, 3, "Fresh shrimp grilled with lemon, garlic, and olive oil.", "", "Grilled Shrimp", 140.0, 12 },
                    { 12, 3, "Basmati rice cooked with mixed seafood and herbs.", "", "Seafood Rice", 130.0, 10 },
                    { 13, 4, "Spicy liver sandwich with tahina and pickles.", "", "Kebda Sandwich", 35.0, 30 },
                    { 14, 4, "Egyptian sausage sandwich with chili and garlic.", "", "Sogo2 Sandwich", 40.0, 30 },
                    { 15, 4, "Tender beef or chicken shawarma wrapped in pita with garlic sauce.", "", "Shawarma Sandwich", 50.0, 25 },
                    { 16, 4, "Deep-fried chickpea balls with tahina and salad in pita bread.", "", "Falafel Sandwich", 30.0, 35 },
                    { 17, 5, "Creamy tahina dip flavored with lemon and garlic.", "", "Tahina Salad", 15.0, 50 },
                    { 18, 5, "Egyptian-style salad with tomatoes, cucumbers, onions, and parsley.", "", "Baladi Salad", 20.0, 40 },
                    { 19, 5, "Healthy chickpea salad with olive oil and lemon dressing.", "", "Chickpea Salad", 25.0, 30 },
                    { 20, 6, "Refreshing black tea infused with fresh mint leaves.", "", "Mint Tea", 20.0, 50 },
                    { 21, 6, "Strong traditional coffee served in a small cup.", "", "Turkish Coffee", 25.0, 40 },
                    { 22, 6, "Freshly blended mango juice made from ripe mangoes.", "", "Mango Juice", 30.0, 35 },
                    { 23, 6, "Thick and sweet guava juice served cold.", "", "Guava Juice", 30.0, 35 },
                    { 24, 6, "Creamy strawberry smoothie with milk and honey.", "", "Strawberry Smoothie", 35.0, 25 },
                    { 25, 7, "Sweet semolina cake soaked in syrup and topped with nuts.", "", "Basbousa", 25.0, 30 },
                    { 26, 7, "Layers of pastry filled with nuts and honey syrup.", "", "Baklava", 35.0, 25 },
                    { 27, 7, "Creamy rice pudding with milk and cinnamon.", "", "Rice Pudding", 30.0, 20 },
                    { 28, 7, "Traditional Egyptian dessert made with puff pastry, milk, and nuts.", "", "Om Ali", 40.0, 18 }
                });

            migrationBuilder.InsertData(
                table: "ProdIngredients",
                columns: new[] { "ProductIngredientId", "IngredientId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 8, 1 },
                    { 7, 14, 2 },
                    { 8, 11, 2 },
                    { 9, 1, 2 },
                    { 10, 6, 2 },
                    { 11, 22, 2 },
                    { 12, 15, 3 },
                    { 13, 10, 3 },
                    { 14, 4, 3 },
                    { 15, 6, 3 },
                    { 16, 8, 3 },
                    { 17, 1, 4 },
                    { 18, 10, 4 },
                    { 19, 6, 4 },
                    { 20, 4, 4 },
                    { 21, 20, 5 },
                    { 22, 8, 5 },
                    { 23, 22, 5 },
                    { 24, 23, 5 },
                    { 25, 10, 6 },
                    { 26, 6, 6 },
                    { 27, 8, 6 },
                    { 28, 9, 6 },
                    { 29, 11, 7 },
                    { 30, 18, 7 },
                    { 31, 21, 7 },
                    { 32, 22, 7 },
                    { 33, 12, 8 },
                    { 34, 6, 8 },
                    { 35, 7, 8 },
                    { 36, 13, 9 },
                    { 37, 6, 9 },
                    { 38, 7, 9 },
                    { 39, 8, 9 },
                    { 40, 16, 10 },
                    { 41, 18, 10 },
                    { 42, 22, 10 },
                    { 43, 23, 10 },
                    { 44, 17, 11 },
                    { 45, 6, 11 },
                    { 46, 22, 11 },
                    { 47, 23, 11 },
                    { 48, 16, 12 },
                    { 49, 17, 12 },
                    { 50, 1, 12 },
                    { 51, 21, 12 },
                    { 52, 23, 12 },
                    { 53, 12, 13 },
                    { 54, 18, 13 },
                    { 55, 7, 13 },
                    { 56, 13, 14 },
                    { 57, 6, 14 },
                    { 58, 7, 14 },
                    { 59, 10, 15 },
                    { 60, 11, 15 },
                    { 61, 6, 15 },
                    { 62, 18, 15 },
                    { 63, 19, 16 },
                    { 64, 18, 16 },
                    { 65, 21, 16 },
                    { 66, 18, 17 },
                    { 67, 22, 17 },
                    { 68, 6, 17 },
                    { 69, 21, 18 },
                    { 70, 23, 18 },
                    { 71, 22, 18 },
                    { 72, 19, 19 },
                    { 73, 21, 19 },
                    { 74, 23, 19 },
                    { 75, 22, 19 },
                    { 76, 31, 20 },
                    { 77, 30, 20 },
                    { 78, 32, 21 },
                    { 79, 33, 22 },
                    { 80, 26, 22 },
                    { 81, 29, 22 },
                    { 82, 34, 23 },
                    { 83, 26, 23 },
                    { 84, 35, 24 },
                    { 85, 26, 24 },
                    { 86, 29, 24 },
                    { 87, 24, 25 },
                    { 88, 25, 25 },
                    { 89, 29, 25 },
                    { 90, 27, 25 },
                    { 91, 24, 26 },
                    { 92, 27, 26 },
                    { 93, 29, 26 },
                    { 94, 28, 26 },
                    { 95, 1, 27 },
                    { 96, 26, 27 },
                    { 97, 25, 27 },
                    { 98, 24, 28 },
                    { 99, 26, 28 },
                    { 100, 27, 28 },
                    { 101, 28, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_ProdIngredients_ProductId",
                table: "ProdIngredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProdIngredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
