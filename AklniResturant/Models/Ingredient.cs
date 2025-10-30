namespace AklniResturant.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductIngredient> ProdIngredients { get; set; }
    }
}
