using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;

namespace Ticaret.Core.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
    }
}
