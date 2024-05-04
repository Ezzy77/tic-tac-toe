
using tic_tac_toe.Services;

namespace tic_tac_toe.Views;

public partial class ProfilePage : ContentPage
{
    private readonly AuthService _authService;

    public ProfilePage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private void OnLogout_Clicked(object sender, EventArgs e)
    {
        _authService.Logout();
        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

    }
}