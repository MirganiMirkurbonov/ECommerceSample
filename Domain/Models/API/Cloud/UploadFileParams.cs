using Microsoft.AspNetCore.Http;

namespace Domain.Models.API.Cloud;

public class UploadFileParams
{
    public IFormFile File { get; set; }
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}