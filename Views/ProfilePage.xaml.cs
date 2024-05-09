
using Android.OS;
using tic_tac_toe.Services;
using tic_tac_toe.ViewModel;

namespace tic_tac_toe.Views;

public partial class ProfilePage : ContentPage
{
    private readonly AuthService _authService;
    private readonly StorageService _storageService;
    // captured pic
    private FileResult _capturedPhoto;  



    public ProfilePage(AuthService authService, StorageService storageService)
    {
        InitializeComponent();
        _authService = authService;
        _storageService = storageService;

        BindingContext = new ProfilePageViewModel();
    }

    private void OnLogout_Clicked(object sender, EventArgs e)
    {
        _authService.Logout();
        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

    }
    
    private async Task SetProfilePicture(string imageName)
    {
        try
        {
            // Get the image URL from Firebase
            string imageUrl = await _storageService.GetImageUrl(imageName);
    
            // Download the image
            HttpClient client = new HttpClient();
            Stream stream = await client.GetStreamAsync(imageUrl);
    
            // Set the image to Image control
            ProfilePicture.Source = ImageSource.FromStream(() => stream);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
        }
    }
    
    
    private async void OnTakePhotoButtonClicked(object sender, EventArgs e)
    {
        //NOTE: Make sure to have necessary permissions in Android Manifest and Info.plist
        // for iOS
         _capturedPhoto = await MediaPicker.CapturePhotoAsync();
       // await LoadPhotoAsync(_capturedPhoto);
    }
    
    
    private async void OnUploadButtonClicked(object sender, EventArgs e)
    {
        // Generate a unique name for each upload
        var imageName = $"{Path.GetRandomFileName()}.jpg";
        if (_capturedPhoto != null) 
        {
            Console.WriteLine("----> captured pic data"+ _capturedPhoto);
        } 
        Console.WriteLine(" -----> Image name: " + imageName);

        
        if (_capturedPhoto != null) {
            try {
                // Open a new file stream 
                using (Stream stream = await _capturedPhoto.OpenReadAsync()) {
                    // Upload the image to Firebase storage
                     var imageUrl = await _storageService.UploadImage(stream, imageName);
                
                    System.Diagnostics.Debug.WriteLine("Image URL: " + imageUrl);
                    Console.WriteLine("-----> Image url: " + imageUrl);
                    
                    // Set the uploaded image as the profile picture
                    await SetProfilePicture(imageName);
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            } finally {
                _capturedPhoto = null;  // reset the photo field
            }
        } else {
            System.Diagnostics.Debug.WriteLine("No photo captured yet to upload");
        }
    }
}