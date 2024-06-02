using DTOValidatorCentralizedConfiguration.Repository;
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
        private readonly IEyesColorRepository _eyesColorRepository;

        public TestLocalizationController(IStringLocalizer<SharedResource> stringLocalizer, IEyesColorRepository eyesColorRepository)
        {
            this._stringLocalizer = stringLocalizer;
            this._eyesColorRepository = eyesColorRepository;
        }

        [HttpGet]
        public string Get()
        {
            return _stringLocalizer["msg_hello"];
        }

        [HttpGet("GetEyesColor")]
        public IActionResult GetEyesColor()
        {
            var eyesColor = _eyesColorRepository.GetEyesColor();
            return Ok(eyesColor);
        }
    }
}
