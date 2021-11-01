using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ticaret.WebAPI.Extensions
{
    public static class ClasimsPrincipalExtensions
    {
            public static string RetrieveEmailFromPrimcipal(this ClaimsPrincipal user)
            {
                return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            }
        
    }
}
