namespace Domain.Models.API.Cloud;

public class FileListViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public long Size { get; set; }
    
    public string Description { get; set; }
    
    public string Extension { get; set; }
}