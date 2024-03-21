using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS.Core.Business;
using NS.Core.Business.MonThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class MonThiController : ControllerBase
    {
        private readonly IMonThiService _monThiService;
        public MonThiController(IMonThiService monThiService)
        {
            this._monThiService = monThiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _monThiService.GetMonHocAsync();
            return Ok(res);
        }


        [HttpGet]
        public async Task<IActionResult> GetPageMonThi([FromQuery]GetPageMonThiRequestModel input)
        {
            var res = await _monThiService.GetPageMonThi(input);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddMonThi([FromBody]MonThiRequestModel monThi)
        {
            var res = await _monThiService.AddNewMonThi(monThi);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMonThi([FromBody]MonThiRequestModel monThi, long id)
        {
            var res = await _monThiService.UpdateMonThi(monThi, id);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMonThi(long id)
        {
            var res = await _monThiService.RemoveMonThi(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<MonThiTuyenSinhResponseModel>>> GetAvailableAndPaging([FromQuery] BasePaginationRequestModel data)
        {
            var s = await _monThiService.GetAvailableAndPaging(data);
            return Ok(s);
        }
    }
}

