using tic_tac_toe.Services;
using tic_tac_toe.ViewModel;

namespace tic_tac_toe.Views;

public partial class LoginPage : ContentPage
{
	private readonly LoginViewModel _loginViewModel;

	
	public LoginPage(AuthService authService)
	{
		InitializeComponent();
		_loginViewModel = new LoginViewModel();
		BindingContext = _loginViewModel;
	}


	private async void OnLogin_Clicked(object sender, EventArgs e)
	{
		try
		{
			var res = await _loginViewModel.AuthService.Login(_loginViewModel.Email.Trim(), _loginViewModel.Password);
			if (res)
			{
				await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
			}
			else
			{
				await DisplayAlert("Error", "Failed to login. Please check your credentials and try again.", "Ok");
			}
		}
		catch (Exception exception)
		{
			await DisplayAlert("Error", "An error occurred: " + exception.Message, "Ok");
		}
	}

	private async void OnSignup_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");	
	}
}


