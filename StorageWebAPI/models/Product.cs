
namespace StorageWebAPI.Models
{
    public class Product(string Name, float UnitPrice, float PricePerWeight, List<string> Categories) {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = Name;
        public float UnitPrice { get; set; } = UnitPrice;
        public float PricePerWeight { get; set; } = PricePerWeight;
        public List<string> Categories { get; set; } = Categories;
        public string CreatedAt { get; set; } = DateTime.Now.ToString();
        public string UpdatedAt { get; set; } = DateTime.Now.ToString();
    }
}