using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ChuyenMucServices;
using NS.Core.Business.CMS;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.SuKienSapToiRequestModel;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers.CMS
{

    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class SuKienSapToiController : ControllerBase
    {
        private readonly ISuKienSapToiService _suKienSapToiServices;

        public SuKienSapToiController(ISuKienSapToiService suKienSapToiService)
        {
           _suKienSapToiServices=suKienSapToiService;
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<SukienSapToiResponseModel>>> GetPagedSuKienSapToi([FromQuery] GetPagedSuKienSapToiRequestModel input)
        {
            var result = await _suKienSapToiServices.GetPagedSuKíenSapToi(input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateSuKienSapToi(SuKienSapToiRequestModel input)
        {
            await _suKienSapToiServices.CreateSuKien(input);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSuKienSapToi(SuKienSapToiRequestModel input)
        {
            await _suKienSapToiServices.UpdateSukien(input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> DeleteSuKienSapToi(long id)
        {
            await _suKienSapToiServices.DeleteSuKien(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SukienSapToiResponseModel>> GetSuKienById(long id)
        {
            var result = await _suKienSapToiServices.GetSukienById(id);
            return Ok(result);
        }



    }
}
