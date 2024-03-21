using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.SampleService;
using NS.Core.Business.TinTuyenDungService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TinTuyenDungController : ControllerBase
    {
        private readonly ITinTuyenDungService _tinTuyenDungService;
        public TinTuyenDungController(ITinTuyenDungService tinTuyenDungService)
        {
            _tinTuyenDungService = tinTuyenDungService;
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<TinTuyenDungResponseModel>>> GetPagedTinTuyenDung([FromQuery] GetPagedTinTuyenDungResquestModel input)
        {
            var result = await _tinTuyenDungService.GetPagedTinTuyenDung(input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTinTuyenDung([FromBody] TinTuyenDungResquestModel input)
        {
            await _tinTuyenDungService.CreateTinTuyenDung(input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTinTuyenDung(long id,[FromBody] TinTuyenDungResquestModel input)
        {
            await _tinTuyenDungService.EditTinTuyenDung(id,input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteTinTuyenDung(long id)
        {
            await _tinTuyenDungService.DeleteTinTuyenDung(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> CapNhatTrangThaiTuyenDung(long id, Enums.TrangThaiTinTuyenDung trangThai)
        {
            await _tinTuyenDungService.CapNhatTrangThaiTuyenDung(id,trangThai);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TinTuyenDungResponseModel>> GetByIdForDialog(long id)
        {
            var result = await _tinTuyenDungService.GetByIdForDialog(id);
            return Ok(result);
        }


    }
}
