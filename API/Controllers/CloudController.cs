using System.Collections.Immutable;
using API.Generics;
using Application.Interfaces;
using Domain.Models.API.Cloud;
using Domain.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CloudController(ICloudService _cloudService) : GenericController<AuthController>
{
    [HttpPost("upload")]
    public async Task<Response<FileUploadedResponse>> Upload(IFormFile file, string description)
    {
        return await _cloudService.UploadFileToCloud(new UploadFileParams { Description = description, File = file, UserId = UserId}, CancellationToken);
    }

    [HttpGet("download")]
    public async Task<IActionResult> Download([FromQuery] Guid id)
    {
        var response = await _cloudService.Download(id, UserId, CancellationToken);
        if(response.Success)
            return File(response.Result!.Stream, response.Result.ContentType);
        return NotFound();
    }

    [HttpDelete]
    public async Task Delete([FromQuery] Guid id)
    {
        await _cloudService.Delete(id, UserId, CancellationToken);
    }

    [HttpGet("get-my-files")]
    public Response<IReadOnlyCollection<FileListViewModel>> GetMyFiles()
    {
        return _cloudService.GetMyFiles(UserId, CancellationToken);
    }
}