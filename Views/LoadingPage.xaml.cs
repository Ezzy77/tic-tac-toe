
using tic_tac_toe.Services;

namespace tic_tac_toe.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;

    public LoadingPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var isLoggedIn = _authService.IsAuthenticated();
        Console.WriteLine("Is logged in ----> " + isLoggedIn);
        if (isLoggedIn )
        {
            // user is logged in
            // redirect to main page
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            // the double // permanently redirect to the new page 

        }
        else
        {
            // user is not logged in
            // redirect to LoginPage
             await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}