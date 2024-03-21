using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.CauLacBoServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers;

[Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
[ApiController]
public class CauLacBoController : Controller
{
    private readonly ICauLacBoService _cauLacBoService;

    public CauLacBoController(ICauLacBoService cauLacBoService)
    {
        _cauLacBoService = cauLacBoService;
    }
    [HttpPost]
    [Consumes(contentType: "multipart/form-data")]
    public async Task<ActionResult> CreateCauLacBo( [FromForm] CauLacBoRequestModel input)
    {

        for (int i = 0; i < Request.Form.Files.Count; i++)
        {
            int index=Convert.ToInt32(Request.Form.Files[i].Name.Substring(13,1));
            input.AnhCauLacBos[index].File = Request.Form.Files[i];
        }
        await _cauLacBoService.CreateCauLacBo(input);
        return Ok();

    }
    [HttpPut]
    [Consumes(contentType: "multipart/form-data")]
    public async Task<ActionResult> EditCauLacBo( [FromForm] CauLacBoRequestModel input)
    {
        
        for (int i = 0; i < Request.Form.Files.Count; i++)
        {
            int index = Convert.ToInt32(Request.Form.Files[i].Name.Substring(13, 1));
            input.AnhCauLacBos[index].File = Request.Form.Files[i];
        }
        await _cauLacBoService.EditCauLacBo(input);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCauLacBo(long id)
    {
        await _cauLacBoService.DeleteCauLacBo(id);
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult<List<CauLacBoResponseModel>>> GetAll()
    {
        var result = await _cauLacBoService.GetAll();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CauLacBoResponseModel>> GetById(long id)
    {
        var result = await _cauLacBoService.GetById(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<CauLacBoRequestModel>> CreateAnhCauLacBo()
    {
        var result = await _cauLacBoService.CreateAnhCauLacBo();
        return Ok(result);
    }





}