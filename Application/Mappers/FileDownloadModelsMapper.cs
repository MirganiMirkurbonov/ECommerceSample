using Amazon.S3.Model;
using Database.Context.Tables;
using Domain.Models.API.Cloud;
using Mapster;

namespace Application.Mappers;

public class FileDownloadModelsMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<GetObjectResponse, FileDownloadResponseModel>()
            .ConstructUsing(src => ConstructParameters(src));
        config
            .NewConfig<UserFile, FileListViewModel>()
            .ConstructUsing(src => ConstructParameters(src));
    }

    private FileListViewModel ConstructParameters(UserFile src)
    {
        return new FileListViewModel
        {
            Description = src.Description,
            Extension = src.Extension,
            Id = src.Id,
            Name = src.Name,
            Size = src.Size
        };
    }

    private static FileDownloadResponseModel ConstructParameters(GetObjectResponse src)
    {
        return new FileDownloadResponseModel
        {
            Stream = src.ResponseStream,
            ContentType = src.Headers.ContentType
        };
    }
}