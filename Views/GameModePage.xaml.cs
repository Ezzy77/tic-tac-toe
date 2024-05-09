namespace tic_tac_toe.Views;

public partial class GameModePage : ContentPage
{
	public GameModePage()
	{
		InitializeComponent();
	}

    private async void PlayAgainstComputerButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AiGameMode());
    }

    private async void PlayOnlineButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MultiplayerBoardPage());
    }
}
