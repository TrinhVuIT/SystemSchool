using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.PhongBanRequestModel;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;

        public PhongBanController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PhongBanResModel>>> GetAll()
        {
            var result = await Task.FromResult(_phongBanService.GetAllPhongBan());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddPhongBan([FromBody] PhongBanRequestModel data)
        {
            _phongBanService.Create(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhongBan([FromBody] PhongBanRequestModel data, long id)
        {
             _phongBanService.Update(id,data);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePhongBan(long id)
        {
             _phongBanService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<PhongBanResModel>>> GetAvailableAndPaging([FromQuery] BasePaginationRequestModel data)
        {
            var res = await _phongBanService.GetPagePhongBan(data);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public  IActionResult GetById(long id)
        {
            var res = _phongBanService.GetPhongBanById(id);
            return Ok(res);
        }
        [HttpGet()]
        public async Task<ActionResult<List<PhongBanResModel>>> GetPhongBanByLoaiPB([FromQuery] LoaiPhongBan loaiPhongBan)
        {
            var res = await _phongBanService.GetPhongBanByLoaiPhongBan(loaiPhongBan);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult ShowHidePhongBan(long id)
        {
            _phongBanService.ChangeShowHidePhongBan(id);
            return Ok();
        }
        [HttpGet()]
        public async Task<ActionResult<List<PhongBanResModel>>> GetPhongBanByLoaiPBActive([FromQuery] LoaiPhongBan loaiPhongBan)
        {
            var res = await _phongBanService.GetPhongBanByLoaiPhongBanActive(loaiPhongBan);
            return Ok(res);
        }
    }
}
