using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.BoPhanLienHeService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BoPhanLienHeController : ControllerBase
    {
        private readonly IBoPhanLienHeServices _boPhanLienHeServices;

        public BoPhanLienHeController(IBoPhanLienHeServices _boPhanLienHeServices)
        {
            this._boPhanLienHeServices = _boPhanLienHeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BoPhanLienHeResponseModel> boPhanLienHes = await _boPhanLienHeServices.GetAll();
            return Ok(boPhanLienHes);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAvailable()
        {
            List<BoPhanLienHeResponseModel> bophanLienHes = await _boPhanLienHeServices.GetAllAvailable();
            return Ok(bophanLienHes);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            BoPhanLienHeResponseModel result = await _boPhanLienHeServices.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            List<BoPhanLienHeResponseModel> result = await _boPhanLienHeServices.Search(keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BoPhanLienHeRequestModel model)
        {
            await _boPhanLienHeServices.Create(model);
            return Ok(model);
        }

        [HttpDelete] 
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _boPhanLienHeServices.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] BoPhanLienHeRequestModel model)
        {
            await _boPhanLienHeServices.Update(id, model);
            return Ok();
        }
    }
}
