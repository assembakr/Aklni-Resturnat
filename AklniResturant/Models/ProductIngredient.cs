﻿namespace AklniResturant.Models
{
    public class ProductIngredient
    {
        public int ProductIngredientId { get; set; }    
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
