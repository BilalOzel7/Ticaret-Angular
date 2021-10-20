using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticaret.Core.DbModels
{
   public class ProductBrand:BaseEntity
    {
        public int ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
    }
}
