using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticaret.WebAPI.Errors;

namespace Ticaret.WebAPI.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    [ApiController]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
