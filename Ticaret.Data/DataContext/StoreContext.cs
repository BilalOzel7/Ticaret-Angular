using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.DbModels;

namespace Ticaret.Data.DataContext
{
   public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


    }
}
