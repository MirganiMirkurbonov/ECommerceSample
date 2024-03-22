namespace Domain.Models.API.Cloud;

public class FileDownloadResponseModel
{
    public Stream Stream { get; set; }
    public string ContentType { get; set; }
}