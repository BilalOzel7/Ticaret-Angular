using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels.Identity;

namespace Ticaret.Core.Interfaces
{
   public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
