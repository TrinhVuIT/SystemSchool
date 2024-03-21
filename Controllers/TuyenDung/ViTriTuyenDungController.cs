using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.TinTuyenDungService;
using NS.Core.Business.ViTriTuyenDungService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Business.ViTriTuyenDungService;
using NS.Core.Commons;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ViTriTuyenDungController : ControllerBase
    {
        private readonly IViTriTuyenDungService _viTriTuyenDungService;
        public ViTriTuyenDungController(IViTriTuyenDungService viTriTuyenDungService)
        {
            _viTriTuyenDungService = viTriTuyenDungService ;
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<ViTriTuyenDung>>> GetPagedViTriTuyenDung([FromQuery] GetPagedViTriTuyenDungResquestModel input)
        {
            var result = await _viTriTuyenDungService.GetPagedViTriTuyenDung(input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateViTriTuyenDung([FromBody] ViTriTuyenDungResquestModel input)
        {
            await _viTriTuyenDungService.CreateViTriTuyenDung(input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditViTriTuyenDung(long id,[FromBody] ViTriTuyenDungResquestModel input)
        {
            await _viTriTuyenDungService.EditViTriTuyenDung(id,input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteViTriTuyenDung(long id)
        {
            await _viTriTuyenDungService.DeleteViTriTuyenDung(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ViTriTuyenDungResponseModel>> GetByIdForDialog(long id)
        {
            var result = await _viTriTuyenDungService.GetByIdForDialog(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ViTriTuyenDungResponseModel>> GetAllForDropDown()
        {
            var result = await _viTriTuyenDungService.GetAllForDropDown();
            return Ok(result);
        }
    }
}
