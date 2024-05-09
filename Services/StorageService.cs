using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;

namespace tic_tac_toe.Services
{
    public class StorageService
    {
        private readonly FirebaseStorage _firebaseStorage;

        public StorageService()
        {
            _firebaseStorage = new FirebaseStorage(Secrets.FirebaseStorageUrl);
        }

        public async Task<string> UploadImage(Stream imageStream, string imageName)
        {
            Console.WriteLine($"Debug: Uploading image - {imageName}");
            try
            {
                var imageUrl = await _firebaseStorage
                    .Child("images")
                    .Child(imageName)
                    .PutAsync(imageStream);

                Console.WriteLine($"Debug: Image uploaded - {imageUrl}");

                return imageUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Upload Image Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw; // re-throwing the exception
            }
        }

        public async Task<string> GetImageUrl(string imageName)
        {
            // Getting the image url by its name
            // Please note that this url could be null if the image doesn't exist
            var imageUrl = await _firebaseStorage
                .Child("images")
                .Child(imageName)
                .GetDownloadUrlAsync();

            return imageUrl;
        }
    }
}