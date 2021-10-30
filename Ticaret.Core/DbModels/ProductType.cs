using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticaret.Core.DbModels
{
   public class ProductType:BaseEntity
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }
}
