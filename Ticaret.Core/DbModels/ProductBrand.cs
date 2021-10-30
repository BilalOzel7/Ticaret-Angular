using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticaret.Core.DbModels
{
   public class ProductBrand:BaseEntity
    {
        [Key]
        public int ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
    }
}
