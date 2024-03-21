using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.LienHeService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class LienHeController : ControllerBase
    {
        private readonly ILienHeService _lienHeService;
        public LienHeController(ILienHeService lienHeService)
        {
            _lienHeService = lienHeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddLienHe([FromBody]AddOrUpdateLienHeRequestModel data)
        {
           await _lienHeService.AddLienHe(data);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLienHe(AddOrUpdateLienHeRequestModel update,long id)
        {
            await _lienHeService.UpdateLienHe(update,id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLienHe(long id)
        {
            await _lienHeService.DeleteLienHe(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
             var res = await _lienHeService.GetAllForDropdown();
            return Ok(res);
        }
    }
}
