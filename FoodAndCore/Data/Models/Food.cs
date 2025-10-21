namespace FoodAndCore.Data.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string? FoodDescription { get; set; }
        public double FoodPrice { get; set; }
        public string? FoodImgUrl { get; set; }
        public int FoodStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
