using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NS.Core.Business.HoSoTuyenSinhService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class HoSoTuyenSinhController : ControllerBase
    {
        private readonly IHoSoTuyenSinhService _hoSoTuyenSinhService;

        public HoSoTuyenSinhController(IHoSoTuyenSinhService hoSoTuyenSinhService)
        {
            _hoSoTuyenSinhService = hoSoTuyenSinhService;
        }

        [HttpGet]
        public async Task<ActionResult<HoSoTuyenSinhResponseModel>> GetPagedHoSo([FromQuery] GetPagedHoSoTuyenSinhRequestModel input)
        {
            var result = await _hoSoTuyenSinhService.GetPagedHoSo(input);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllAvailable()
        {
            var res = _hoSoTuyenSinhService.GetAllAvailable();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoTuyenSinhDetailsResponseModel>> GetChiTietHoSoTuyenSinh(long id)
        {
            var result = await _hoSoTuyenSinhService.GetChiTietHoSoTuyenSinh(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoThiResponseModel>> GetHoSoThiById(long id)
        {
            var res = await _hoSoTuyenSinhService.GetHoSoThiById(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<HoSoTuyenSinhResponseModel>> GetHoSoTheoTaiKhoan(long taiKhoanId)
        {
            var result = await _hoSoTuyenSinhService.GetHoSoTheoTaiKhoan(taiKhoanId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHoSoTuyenSinh(CreateOrUpdateHoSoRequestModel hoSo)
        {
            await _hoSoTuyenSinhService.CreateHoSoTuyenSinh(hoSo);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoSoTuyenSinh(long id, CreateOrUpdateHoSoRequestModel hoSo)
        {
            await _hoSoTuyenSinhService.UpdateHoSoTuyenSinh(id, hoSo);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrangThaiHoSoTS(long id, int index)
        {
            await _hoSoTuyenSinhService.UpdateTrangThaiHoSoTS(id, index);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateListTrangThaiHoSoTS(List<HoSoTuyenSinhResponseModel> hoSo, int index)
        {
            await _hoSoTuyenSinhService.UpdateListTrangThaiHoSoTS(hoSo, index);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> DeleteListHoSo(List<long> id)
        {
            await _hoSoTuyenSinhService.DeleteHoSoTuyenSinh(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<HoSoTrungResponseModel>> GetPagedHoSoTrung([FromQuery] GetPagedHoSoTrungRequestModel input)
        {
            var result = await _hoSoTuyenSinhService.GetPagedHoSoTrung(input);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> GhepHoSo(long id, List<long> input)
        {
            await _hoSoTuyenSinhService.GhepHoSo(id, input);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<DanhSachDuThiResponseModel>>> GetDanhSachDuThiAndPaging([FromQuery]GetDanhSachDuThiAndPagingAndFilterRespuestModel paramsModel)
        {
            var s = await _hoSoTuyenSinhService.GetDanhSachDuThiAndPaging(paramsModel);
            return Ok(s);
        }
        [HttpGet]
        public async Task<IActionResult> GetHeDaoTaoAvailableForDropDown()
        {
            var result = await _hoSoTuyenSinhService.GetHeDaoTaoAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetLopDangKiAvailableForDropDown()
        {
            var result = await _hoSoTuyenSinhService.GetLopDangKiAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTrangThaiDuThiAvailableForDropDown()
        {
            var result = await _hoSoTuyenSinhService.GetTrangThaiDuThiAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTheDuThiAvailableForDropDown()
        {
            var result = await _hoSoTuyenSinhService.GetTheDuThiAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetKyTuyenSinhAvailableForDropDown()
        {
            var result = await _hoSoTuyenSinhService.GetKyTuyenSinhAvailableForDropDown();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<HoSoTuyenSinhResponseModel>> GetPagedHoSoTuyenSinhByKyTuyenSinhId([FromQuery] GetPagedHoSoTuyenSinhByKyTuyenSinhIdRequestModel input)
        {
            var result = await _hoSoTuyenSinhService.GetPagedHoSoTuyenSinhByKyTuyenSinhId(input);
            return Ok(result);
        }
    }
}
