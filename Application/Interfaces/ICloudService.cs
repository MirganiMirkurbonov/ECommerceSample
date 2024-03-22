using Domain.Models.API.Cloud;
using Domain.Models.Common;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface ICloudService
{
    Task<Response<FileUploadedResponse>> UploadFileToCloud(UploadFileParams fileParams,
        CancellationToken cancellationToken);

    Task<Response<FileDownloadResponseModel>> Download(Guid id, Guid userId, CancellationToken cancellationToken);

    Task Delete(Guid id, Guid userId, CancellationToken cancellationToken);
    Response<IReadOnlyCollection<FileListViewModel>> GetMyFiles(Guid userId, CancellationToken cancellationToken);
}