using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticaret.Core.DbModels
{
   public class Product:BaseEntity
    {

        //https://github.com/ylmzertg/AngularE-Commerce.git
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int? ProductBrandId { get; set; }

    }
}
