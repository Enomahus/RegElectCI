namespace Application.Common.Interfaces.Services
{
    public interface IFileService
    {
        Task DeleteFileByIdAsync(Guid documentId, CancellationToken cancellationToken);
        Task DeleteFilesByIdAsync(
            IEnumerable<Guid> documentIds,
            CancellationToken cancellationToken
        );
        Task<Stream> GetFileDownloadStreamAsync(
            Guid documentId,
            CancellationToken cancellationToken
        );
        Task<Guid> UploadFileAsync(
            Stream stream,
            string fileName,
            string contentType,
            CancellationToken cancellationToken,
            Guid? existingDocumentId = null
        );
        Task<Guid> UploadFileNoTransactionAsync(
            Stream stream,
            string fileName,
            string contentType,
            CancellationToken cancellationToken,
            Guid? existingDocumentId = null
        );
    }
}
