using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CookBooks.Helpers;
using CookBooks.Interfaces;
using Microsoft.Extensions.Options;


namespace CookBooks.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var Acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret 
                );
            _cloudinary = new Cloudinary(Acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string ImageUrl)
        {
            string publicId = getPublicIdFromUrl(ImageUrl);
            var deleteParam = new DeletionParams(publicId);
            var result =  await _cloudinary.DestroyAsync(deleteParam);

            return result;

        }

        public string getPublicIdFromUrl(string URL)
        {
            int startIndexOfUrl = URL.LastIndexOf("/") + 1;
            int lenghOfPublicId = URL.LastIndexOf(".") - startIndexOfUrl;

            string publicId = URL.Substring(startIndexOfUrl, lenghOfPublicId);

            return publicId;
        }
    }
}
