using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace iTransition.Forms.Infrastructure.Utilities
{
    public class ImageServiceUtility : IImageServiceUtility
    {
        private readonly Cloudinary _cloudinary;

        public ImageServiceUtility(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string?> UploadImage(IFormFile? picture)
        {
            if (picture == null || picture.Length == 0)
                return null;

            await using var stream = picture.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(picture.FileName, stream),
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false,
                Folder = "templates"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl?.AbsoluteUri;
        }
    }
}
