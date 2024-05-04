
using tic_tac_toe.ViewModel;

namespace tic_tac_toe.Views;

public partial class RegisterPage 
{
    private readonly RegisterViewModel _registerViewModel;
    
    
    

    public RegisterPage()
    {
        InitializeComponent();
        _registerViewModel = new RegisterViewModel();
        BindingContext = _registerViewModel;
    }

    private async void OnLogin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");	
    }

    private async void OnRegister_Clicked(object sender, EventArgs e)
    {

        if (await _registerViewModel.AuthService.Register(_registerViewModel.Email, _registerViewModel.Password))
        {
            await DisplayAlert("Success", "Registered Successfully", "OK");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            return;
        }

        await DisplayAlert("Fail", "Registration failed", "OK");
    }
}