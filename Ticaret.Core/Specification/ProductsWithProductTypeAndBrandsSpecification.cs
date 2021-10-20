using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;

namespace Ticaret.Core.Specification
{
   public class ProductsWithProductTypeAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
               :base(x=>
               (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.ProductName.ToLower().Contains(productSpecParams.Search))
               &&
               (!productSpecParams.BrandId.HasValue || x.ProductBrandId== productSpecParams.BrandId)
               &&
               (!productSpecParams.TypeId.HasValue || x.ProductTypeId== productSpecParams.TypeId)
               )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            // AddOrderBy(x => x.ProductName);

            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                            AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.ProductName);
                        break;
                }
            }
        }

        public ProductsWithProductTypeAndBrandsSpecification(int id):base(x=>x.ProductId==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
