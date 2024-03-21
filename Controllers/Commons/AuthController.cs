using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System.Linq;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterData data)
        {
            string origin = Request.Headers[Constants.EmailConstants.REQUEST_HEADER_KEY_ORIGIN].ToString();
            await _authService.Register(data,origin);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordData data)
        {
            await _authService.ChangePassword(data);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            string origin = Request.Headers[Constants.EmailConstants.REQUEST_HEADER_KEY_ORIGIN].ToString();
            await _authService.ForgotPassword(model,origin);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] SignInData data)
        {
            LoginResponseModel result = await _authService.Login(data);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> VerifyEmail([FromQuery] Guid key)
        {
            await _authService.VerifyEmail(key);
            return Ok();
        }
    }
}