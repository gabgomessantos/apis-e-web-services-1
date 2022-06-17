using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SOAPConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        public MainController()
        {

        }

        protected ActionResult CustomResponse(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}
