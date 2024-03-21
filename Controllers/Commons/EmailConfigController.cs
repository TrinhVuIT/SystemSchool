using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS.Core.Business.EmailConfigServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.EmailTemplateRequestModel;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class EmailConfigController : ControllerBase
    {
        public readonly IEmailConfigServices _emailConfigServices;

        public EmailConfigController(IEmailConfigServices emailConfigServices)
        {
            this._emailConfigServices = emailConfigServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmailConfigResponseModel>>> GetAllEmail()
        {
            var res = await _emailConfigServices.GetAll();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailConfigResponseModel>> GetById(long id)
        {
            var ret = _emailConfigServices.GetById(id);
            return Ok(ret);
        }
        [HttpPost]
        public async Task<ActionResult<EmailConfigResponseModel>> AddNewEmailConfig([FromBody] EmailConfigRequestModel newEmail)
        {
            await _emailConfigServices.AddNewEmailConfig(newEmail);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EmailConfigResponseModel>> UpdateEmailConfig(long id, [FromBody] EmailConfigRequestModel updateEmail)
        {
            await _emailConfigServices.UpdateEmailConfig(id, updateEmail);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(long id)
        {
          await _emailConfigServices.DeleteEmail(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<EmailConfigResponseModel>>> GetAllEmailPageing([FromQuery] GetPagedEmailTemplateAndFilter page)
        {
            var res = await _emailConfigServices.GetAllListEmailPage(page);
            return Ok(res);
        }
    }
}
