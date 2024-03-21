using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.NamHocService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class NamHocController : ControllerBase
    {
        private readonly INamHocService _namHocService;

        public NamHocController(INamHocService namHocService)
        {
            this._namHocService = namHocService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNamHocById([FromQuery]long id)
        {
            var res = await _namHocService.GetNamHocById(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetNamHocAsync()
        {
            var res = await _namHocService.GetNamHocAsync();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableNamHoc()
        {
            var res = await _namHocService.GetAvailableNamHoc();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetPageNamHoc([FromQuery]GetPageNamHocResquestModel input)
        {
            var res = await _namHocService.GetPagedNamHoc(input);
            return Ok(res);
        }
        [HttpPost] 
        public async Task<IActionResult> AddNewNamHoc([FromBody] NamHocRequestModel namHoc)
        {
            var res = await _namHocService.AddNewNamHoc(namHoc);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNamHoc([FromBody] NamHocRequestModel namHoc, long id)
        {
            var res = await _namHocService.UpdateNamHoc(namHoc, id);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveNamHoc(long id)
        {
            var res = await _namHocService.DeleteNamHoc(id);
            return Ok(res);
        }
    }
}
