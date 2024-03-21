using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.HocPhiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.HocPhi;
using NS.Core.Models.RequestModels.HocPhiRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.HocPhiResponse;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class HocPhiController : ControllerBase
    {
        private readonly IHocPhiService _hocPhiService;
        public HocPhiController (IHocPhiService hocPhiService)
        {
            _hocPhiService = hocPhiService;
        }

        [HttpGet("{namHocId}")]
        public async Task<ActionResult<NamHocPhiResModel>> GetByNamHocId(long namHocId)
        {
            var res = await Task.FromResult(_hocPhiService.GetByNamHocId(namHocId));
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHocPhi([FromBody]NamHocPhiReqModel input)
        {
            _hocPhiService.CreateOrUpdateHocPhiByNamHocId(input);
            return Ok();
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           

        [HttpPut]
        public async Task<IActionResult> EditHocPhi([FromBody]NamHocPhiReqModel input)
        {
            _hocPhiService.CreateOrUpdateHocPhiByNamHocId(input);
            return Ok();
        }
        [HttpDelete("{hocPhiId}")]
        public async Task<IActionResult> DeleteHocPhi( long hocPhiId)
        {
           await _hocPhiService.DeleteHocPhi(hocPhiId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await Task.FromResult(_hocPhiService.GetAllNamHocPhi());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietHocPhiById(long id)
        {
            var res = await Task.FromResult(_hocPhiService.GetChiTieHocPhiById(id));
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<List<HeDaoTaoResponseModel>>> GetHeDaoTaoForDropdown()
        {
            var result = _hocPhiService.GetHeDaoTaoForDropDown();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHocPhiByNamHocId([FromBody] HocPhiRequestModel input)
        {
           await _hocPhiService.CreateHocPhi(input);
            return Ok();
        }
        [HttpGet]
        public async Task<List<HocPhiResponseModel>> GetAllHocPhi()
        {
           return await  _hocPhiService.GetAllHocPhi();           
        }
        [HttpPut("{hocPhiId}")]
        public async Task<IActionResult> UpdateHocPhi(long hocPhiId,UpdateHocPhiReqModel data)
        {
            await _hocPhiService.UpdateHocPhi(hocPhiId, data);
            return Ok();
        }
    }
}
