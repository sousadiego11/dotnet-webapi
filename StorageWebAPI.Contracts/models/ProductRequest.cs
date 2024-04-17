
using System.ComponentModel.DataAnnotations;

namespace StorageWebAPI.Contracts.Models {
    public class ProductRequest {
        [Required]
        public string Name {get; set;}  = "";
        public float UnitPrice {get; set;}
        public float PricePerWeight {get; set;}
        [Required]
        public List<string> Categories {get; set;} = [];
    }
}