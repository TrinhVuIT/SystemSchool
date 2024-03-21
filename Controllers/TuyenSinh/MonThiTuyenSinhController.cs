using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.MonThiTuyenSinhService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.MonThiTuyenSinh;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class MonThiTuyenSinhController : ControllerBase
    {
        private IMonThiTuyenSinhService _service;
        public MonThiTuyenSinhController(IMonThiTuyenSinhService monThiTuyenSinhService)
        {
            _service = monThiTuyenSinhService;
        }
        [HttpPost]
        public async Task<IActionResult> AddMonThi([FromBody] AddOrUpdateMonThiTuyenSinhRequestModel newMonThi)
        {
            await _service.AddMonThiTuyenSinh(newMonThi);
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateMonThi(long id, [FromBody] AddOrUpdateMonThiTuyenSinhRequestModel updateMonThi)
        {
            await _service.UpdateMonThiTuyenSinh(id, updateMonThi);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMonThi(long id)
        {
            _service.DeleteMonThiTuyenSinh(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetMonThi();
            return Ok(res);
        }
        [HttpGet]
        public  IActionResult GetById(long id)
        {
            var result =  _service.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<MonThiTuyenSinhResponseModel>>> GetAvailableAndPaging([FromQuery] MonThiTuyenSinhPagedModel data)
        {
            var result = await _service.GetAvailableAndPaging(data);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetKyTuyenSinhAvailableForDropDown()
        {
            var result = await _service.GetKyTuyenSinhAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetLopDuThiAvailableForDropDown()
        {
            var result = await _service.GetLopDuThiAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetMonThiAvailableForDropDown()
        {
            var result = await _service.GetMonThiAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetHeDaoTaoAvailableForDropDown()
        {
            var result = await _service.GetHeDaoTaoAvailableForDropDown();
            return Ok(result);
        }

 
    }
}
