
using System.ComponentModel.DataAnnotations;

namespace StorageWebAPI.Contracts.Models {
    public class ProductResponse {
        public Guid Id {get; set; }
        [Required]
        public string Name {get; set; } = "";
        public float UnitPrice {get; set; }
        public float PricePerWeight {get; set; }
        [Required]
        public List<string> Categories {get; set; } = [];
        [Required]
        public string CreatedAt {get; set; } = "";
        [Required]
        public string UpdatedAt {get; set; } = "";
    }
}