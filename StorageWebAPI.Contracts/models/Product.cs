using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageWebAPI.Contracts.models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
    }
}