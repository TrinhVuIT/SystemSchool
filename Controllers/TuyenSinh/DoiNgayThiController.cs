using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.DoiNgayThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class DoiNgayThiController : ControllerBase
    {
        private readonly IDoiNgayThiService _doiNgayThiService;

        public DoiNgayThiController(IDoiNgayThiService doiNgayThiService)
        {
            _doiNgayThiService = doiNgayThiService;
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<DoiNgayThiResponseModel>>> GetAll([FromQuery] DoiNgayThiRequestModel model)
        {
            var result = await _doiNgayThiService.GetAll(model);
            return Ok(result);
        }        
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<HeDaoTaoDropdownResponse>>> GetHeDaoTaoDropDown([FromQuery] long kyTuyenSinhId)
        {
            var result = await _doiNgayThiService.GetHeDaoTaoDropDown(kyTuyenSinhId);
            return Ok(result);
        }  
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<HeDaoTaoDropdownResponse>>> GetLopDangKyDropDown([FromQuery] long kyTuyenSinhId)
        {
            var result = await _doiNgayThiService.GetLopDangKyDropDown(kyTuyenSinhId);
            return Ok(result);
        }

    }
}
