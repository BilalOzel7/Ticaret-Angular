using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels.Identity;

namespace Ticaret.Infrastructure.DataContext
{
   public class AppIdentityDbcontextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bilal",
                    Email = "mbozel07@gmail.com",
                    UserName = "mbozel07@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Bilal",
                        LastName = "Özel",
                        Street = "Istanbul Cad",
                        City = "Istanbul",
                        State = "TR",
                        ZipCode = "34600"
                    }
                };
                await userManager.CreateAsync(user, "A123456");
            }
        }
    }
}
