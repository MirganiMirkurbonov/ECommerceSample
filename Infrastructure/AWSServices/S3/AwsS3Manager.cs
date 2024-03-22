using Amazon.S3;
using Amazon.S3.Model;
using Domain.Models.Common;
using Domain.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.AWSServices.S3;

public class AwsS3Manager(
    IAmazonS3 _amazonS3,
    IOptions<AwsS3Options> _options) : IAwsS3Manager
{
    public async Task<Response<PutObjectResponse>> UploadDocumentAsync(Guid id, IFormFile file, CancellationToken cancellationToken)
    {
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = _options.Value.BucketName,
            Key = $"document/{id}",
            ContentType = file.ContentType,
            InputStream = file.OpenReadStream(),
            Metadata =
            { 
                ["x-amz-meta-originalname"] = file.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(file.FileName)
            }
        };
        return await _amazonS3.PutObjectAsync(putObjectRequest, cancellationToken);
    }

    public async Task<Response<GetObjectResponse>> DownloadDocumentAsync(Guid id, CancellationToken cancellationToken)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _options.Value.BucketName,
            Key = $"document/{id}"
        };

        return await _amazonS3.GetObjectAsync(getObjectRequest, cancellationToken);
    }

    public async Task DeleteDocumentAsync(Guid id, CancellationToken cancellationToken)
    {
        var deleteObjectRequest = new DeleteObjectRequest()
        {
            BucketName = _options.Value.BucketName,
            Key = $"document/{id}"
        };
        await _amazonS3.DeleteObjectAsync(deleteObjectRequest, cancellationToken);
    }
}