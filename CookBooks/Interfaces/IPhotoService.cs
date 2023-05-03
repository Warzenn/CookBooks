using CloudinaryDotNet.Actions;

namespace CookBooks.Interfaces
{
    public interface IPhotoService
    {

        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
