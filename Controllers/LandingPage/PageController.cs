using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.CMSLandingPage;
using NS.Core.Business.FileService;
using NS.Core.Business.HocPhiService;
using NS.Core.Business.LandingPageService;
using NS.Core.Business.VideoService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.CMSLandingPage;
using NS.Core.Models.RequestModels.landingPage;
using NS.Core.Models.RequestModels.QuyDinhNhapHocReqestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.CMSLandingPage;
using NS.Core.Models.ResponseModels.HocPhiResponse;
using NS.Core.Models.ResponseModels.LandingPage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NS.Core.API.Controllers.LandingPage
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly ILandingPage _service;
        private readonly IVideo _videoService;
        private readonly IHocPhiService _hocPhiService;
        private readonly IGetPageService _getPageService;
        private readonly IFile _fileService;
        private readonly IConfiguration _configuration;
        public PageController(ILandingPage service, IVideo video, IHocPhiService hocPhi,
            IGetPageService getPageService, IFile fileService, IConfiguration configuration)
        {
            _service = service;
            _videoService = video;
            _hocPhiService = hocPhi;
            _getPageService = getPageService;
            _fileService = fileService;
            _configuration = configuration;
        }

        [HttpDelete("{caiDatTongTheId}")]
        public async Task<IActionResult> DeleteCaiDatTongThe(long caiDatTongTheId)
        {
            await _getPageService.DeleteCaiDatTongThe(caiDatTongTheId);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCaiDatTongThe(long trangId, CaiDatTongTheRequestModel input)
        {
            await _getPageService.CreateCaiDatTongThe(trangId, input);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CaiDatTongTheResponseModel>> GetCaiDatTongTheById(long id)
        {
            var result = await _getPageService.GetCaiDatTongTheById(id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LandingPageResponseModel>> Get(int id)
        {
            LandingPageResponseModel result = await _service.GetDetail(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ThoiGianBieuPageResponseModel>> ThoiGianBieu()
        {
            ThoiGianBieuPageResponseModel result = await _service.GetThoiGianBieu();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<VideoResponseModel>>> Video([FromQuery] VideoRequestModel model)
        {
            var result = await _videoService.GetAllVideo(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<Task<List<HocPhiResponseModel>>>> HocPhi()
        {
            //var result = await _hocPhiService.GetAll();
            return Ok();
        }

        [HttpGet("{caiDatTongTheId}")]
        public async Task<ActionResult<BasePaginationResponseModel<CaiDatChitietResponseModel>>> GetPagedCaiDatChiTiet(long caiDatTongTheId, [FromQuery] GetPagedCaiDatChiTietRequestModel input)
        {
            var result = await _getPageService.GetPagedCaiDatChiTiet(caiDatTongTheId, input);
            return Ok(result);
        }

        [HttpGet("{trangId}")]
        public async Task<List<CaiDatTongTheResponseModel>> GetCaiDatTongThe(long trangId)
        {
            var res = await _getPageService.GetCaiDatTongThe(trangId);
            return res;
        }

        [HttpPut("{caiDatTongTheId}")]
        public async Task<IActionResult> EditCaiDatTongThe(long caiDatTongTheId, CaiDatTongTheRequestModel input)
        {
            await _getPageService.EditCaiDatTongThe(caiDatTongTheId, input);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateQuyDinhNhapHoc([FromForm]QuyDinhNhapHocRequestModel data)
        {
            await _getPageService.UpdateQuyDinhNhapHoc(data);
            return Ok();
        }

        #region Cài đặt chi tiết

        [HttpGet("{caiĐatChiTietId}")]
        public async Task<ActionResult<CaiDatChitietResponseModel>> GetCaiDatChiTietById(long caiĐatChiTietId)
        {
            var result = await _getPageService.GetCaiDatChiTietById(caiĐatChiTietId);
            return Ok(result);
        }
        
        [HttpPost("{caiDatTongTheId}")]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateCaiDatChiTiet(long caiDatTongTheId, [FromForm] CaiDatChiTietRequestModel input)
        {
           
            await _getPageService.CreateCaiDatChiTiet(caiDatTongTheId, input);
            return Ok();
        }
        
        [HttpPut("{caiDatChiTietId}")]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateCaiDatChiTiet(long caiDatChiTietId, [FromForm] CaiDatChiTietRequestModel input)
        {
            
            await _getPageService.UpdateCaiDatChiTiet(caiDatChiTietId, input);
            return Ok();
        }
        
        [HttpDelete("{caiDatChiTietId}")]
        public async Task<IActionResult> DeleteCaiDatchiTiet(long caiDatChiTietId)
        {
            await _getPageService.DeleteCaiDatChiTiet(caiDatChiTietId);
            return Ok();
        }

        #endregion
        
    }
}
