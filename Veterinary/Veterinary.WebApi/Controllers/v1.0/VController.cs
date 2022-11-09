using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class VController : BaseApiController
    {
        [HttpGet]
        public Task GetAll()
        {
            return null;
        }
    }
}
