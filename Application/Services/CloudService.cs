using System.Collections.Immutable;
using System.Net;
using Application.Interfaces;
using Database.Context.Tables;
using Database.Interfaces;
using Domain.Enumerators;
using Domain.Models.API.Cloud;
using Domain.Models.Common;
using Infrastructure.AWSServices.S3;
using Mapster;

namespace Application.Services;

public class CloudService(
    IAwsS3Manager _awsS3Manager,
    IGenericRepository<UserFile> _repository) : ICloudService
{
    public async Task<Response<FileUploadedResponse>> UploadFileToCloud(
        UploadFileParams fileParams,
        CancellationToken cancellationToken)
    {
        var newFile = fileParams.Adapt<UserFile>();
        var fileInDb = await _repository.Insert(newFile, cancellationToken);

        var result = await _awsS3Manager.UploadDocumentAsync(fileInDb.Id, fileParams.File, cancellationToken);
        if (result.Success == false)
            return new ErrorResponse(HttpStatusCode.InternalServerError, EResponseCode.InternalServerError);
        
        return fileInDb.Adapt<FileUploadedResponse>();
    }

    public async Task<Response<FileDownloadResponseModel>> Download(
        Guid id,
        Guid userId,
        CancellationToken cancellationToken)
    {
        var fileInDb = await _repository.GetBy(x => x.Id == id && x.UserId == userId, cancellationToken);
        if (fileInDb == null)
            return new ErrorResponse(HttpStatusCode.NotFound, EResponseCode.FileNotFound);

        var fileInAws = await _awsS3Manager.DownloadDocumentAsync(fileInDb.Id, cancellationToken);
        return fileInAws.Result.Adapt<FileDownloadResponseModel>();
    }

    public async Task Delete(
        Guid id,
        Guid userId,
        CancellationToken cancellationToken)
    {
        var file = await _repository.GetBy(x => x.Id == id && x.UserId == userId, cancellationToken);
        if(file != null)
            await _awsS3Manager.DeleteDocumentAsync(id, cancellationToken);
    }

    public Response<IReadOnlyCollection<FileListViewModel>> GetMyFiles(Guid userId, CancellationToken cancellationToken)
    {
        var files = _repository
            .Query(x => x.UserId == userId, cancellationToken)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => x.Adapt<FileListViewModel>())
            .ToImmutableList();
        
        return files;
    }
}