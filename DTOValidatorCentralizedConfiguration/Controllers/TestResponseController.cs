using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ResultNet;

namespace DTOValidatorCentralizedConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResponseController : ControllerBase
    {
        private readonly IStringLocalizer _stringLocalizer;

        public TestResponseController(IStringLocalizer stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                Result.Failure().WithCode("msg_hello").WithMessage("Como asi").WithLocalizedMessage("msg_hello")
                );
        }
    }
}
