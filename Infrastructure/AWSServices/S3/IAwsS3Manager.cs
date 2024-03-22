using Amazon.S3.Model;
using Domain.Models.Common;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.AWSServices.S3;

public interface IAwsS3Manager
{
    Task<Response<PutObjectResponse>> UploadDocumentAsync(Guid id, IFormFile file, CancellationToken cancellationToken);
    Task<Response<GetObjectResponse>> DownloadDocumentAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteDocumentAsync(Guid id, CancellationToken cancellationToken);
}