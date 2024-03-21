using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Business.HeDaoTaoService;
using NS.Core.Business.KyTuyenSinhService;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Commons.Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class KyTuyenSinhController : ControllerBase
    {
        private readonly IKyTuyenSinhService _kyTuyenSinhService;
        public KyTuyenSinhController(IKyTuyenSinhService kyTuyenSinhService)
        {
            this._kyTuyenSinhService = kyTuyenSinhService;
        }
        [HttpGet]
        public async Task<ActionResult<List<KyTuyenSinhResponseModel>>> GetAll()
        {
            var result = await _kyTuyenSinhService.GetAll();
            return Ok(result);
        }
        [HttpGet("{kyTuyenSinhId}")]
        public async Task<ActionResult<KyTuyenSinhResponseModel>> GetKyTuyenSinhById(long kyTuyenSinhId)
        {
            var result = await _kyTuyenSinhService.GetKyTuyenSinhById(kyTuyenSinhId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateKyTuyenSinh(CreateOrUpdateKyTuyenSinhModel data)
        {
            await _kyTuyenSinhService.CreateKyTuyenSinh(data);
            return Ok();
        }
        [HttpPut("{kyTuyenSinhId}")]
        public async Task<IActionResult> UpdateKyTuyenSinh(long kyTuyenSinhId, CreateOrUpdateKyTuyenSinhModel data)
        {
            await _kyTuyenSinhService.UpdateKyTuyenSinh(kyTuyenSinhId, data);
            return Ok();
        }
        [HttpDelete("{kyTuyenSinhId}")]
        public async Task<IActionResult> DeleteKyTuyenSinh(long kyTuyenSinhId)
        {
            await _kyTuyenSinhService.DeleteKyTuyenSinh(kyTuyenSinhId);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<KyTuyenSinhResponseModel>>> GetPagedKyTuyenSinh([FromQuery] KyTuyenSinhRequestModel input)
        {
            var result = await _kyTuyenSinhService.GetPagedKyTuyenSinh(input);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<KyTuyenSinhResponseModel>>> GetKhoiForDropdown()
        {
            var result =  _kyTuyenSinhService.GetKhoiForDropdown();
            return  Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<KyTuyenSinhResponseModel>>> GetNamHocForDropdown()
        {
            var result = _kyTuyenSinhService.GetNamHocForDropdown();
            return Ok(result);
        }
    }
}
