namespace StorageWebAPI.Contracts.models
{
    public class Product
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public float Price { get; set; }
    }
}