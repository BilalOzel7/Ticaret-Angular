using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;

namespace Ticaret.Core.Interfaces
{
   public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrPaymentIntent(string basketId);
    }
}
