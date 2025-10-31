namespace AklniResturant.Models.View_Models
{
    public class ProductEditVM
    {
        public Product Product { get; set; } = new Product();

        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Ingredient>? Ingredients { get; set; }

        // For checkboxes
        public int[] SelectedIngredientIds { get; set; } = Array.Empty<int>();

        // For file upload
        public IFormFile? ImageFile { get; set; }
    }
}
