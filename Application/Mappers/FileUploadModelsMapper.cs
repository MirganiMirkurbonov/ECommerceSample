using Amazon.S3.Model;
using Database.Context.Tables;
using Domain.Models.API.Cloud;
using Mapster;

namespace Application.Mappers;

public class FileUploadModelsMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<UploadFileParams, UserFile>()
            .ConstructUsing(src => ConstructUsing(src));

        config
            .NewConfig<UserFile, FileUploadedResponse>()
            .ConstructUsing(src => ConstructUsing(src));
    }

    private FileUploadedResponse ConstructUsing(UserFile src)
    {
        return new FileUploadedResponse
        {
            Id = src.Id,
            Description = src.Description,
            Name = src.Name,
            Size = src.Size,
            Extension = src.Extension
        };
    }

    private UserFile ConstructUsing(UploadFileParams src)
    {
        return new UserFile
        {
            Description = src.Description,
            Extension = Path.GetExtension(src.File.FileName),
            UserId = src.UserId,
            Size = src.File.Length,
            Name = src.File.FileName,
            Path = "test",
        };
    }
}