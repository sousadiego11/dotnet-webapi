using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageWebAPI.Contracts.Models;
using StorageWebAPI.Models;

namespace StorageWebAPI.Mapping
{
    public class ProductMapping {

        public static ProductResponse FromDbEntityToResponse(Product product) {
            return new ProductResponse() {
                Categories = product.Categories,
                Id = product.Id,
                Name = product.Name,
                PricePerWeight = product.PricePerWeight,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
            };
        }

        public static Product FromRequestToDbEntity(ProductRequest req) {
            return new Product(req.Name, req.UnitPrice, req.PricePerWeight, req.Categories);
        }
        
    }
}