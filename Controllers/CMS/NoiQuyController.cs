using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.NoiQuyService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.NoiQuyRequest;
using NS.Core.Models.ResponseModels.NoiQuy;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class NoiQuyController : ControllerBase
    {
        private readonly INoiQuyService _noiQuyService;
        public NoiQuyController(INoiQuyService noiQuyService)
        {
            _noiQuyService = noiQuyService;
        }
        [HttpGet]
        public async Task<ActionResult<List<NoiQuyResponseModel>>> GetPagedNoiQuy([FromQuery] GetPagedNoiQuyRequest input)
        {
            var result = await _noiQuyService.GetPageNoiQuy(input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNoiQuy([FromBody] CreateOrUpdateNoiQuyRequest data)
        {
            await _noiQuyService.CreateNoiQuy(data);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoiQuy(long id, [FromBody] CreateOrUpdateNoiQuyRequest data)
        {
            await _noiQuyService.UpdateNoiQuy(id, data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoiQuy(long id)
        {
            await _noiQuyService.DeleteNoiQuy(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoiQuyResponseModel>> GetNoiQuyById(long id)
        {
            var result = await _noiQuyService.GetById(id);
            return Ok(result);
        }
    }
}
