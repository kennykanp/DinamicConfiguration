using DTOValidatorCentralizedConfiguration.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DTOValidatorCentralizedConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestLocalizationController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public TestLocalizationController(IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public string Get()
        {
            return _stringLocalizer["msg_hello"];
        }
    }
}
