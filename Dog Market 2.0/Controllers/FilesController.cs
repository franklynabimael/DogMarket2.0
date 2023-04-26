using Dog_Market_2._0.Services;
using Dog_Market_2._0.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dog_Market_2._0.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IFileServices _fileService;

    public FilesController(IFileServices fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("image")]
    public async Task<ActionResult<FileResponse>> UploadImages()
    {
        try
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files[0];
            var response = await _fileService.FileManage(file);
            if (!response.isSuccesful)
            {
                ModelState.AddModelError("File", response.Message);
                return BadRequest(ModelState);
            }
            var dbPath = Path.Combine(response.FileLocation, response.FileName);
            return Ok(new { dbPath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
}
