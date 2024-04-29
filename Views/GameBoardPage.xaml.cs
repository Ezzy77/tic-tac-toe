namespace tic_tac_toe.Views;

public partial class GameBoardPage : ContentPage
{
	public GameBoardPage()
	{
		InitializeComponent();
	}

	public void OnButtonClicked(object sender, EventArgs e)
	{
		Console.WriteLine("Clicked");
	}

    public void OnResetClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Reset");
    }

    private async void EndGameButton_Clicked(object sender, EventArgs e)
    {
        // Perform any necessary actions to end the game
        await Navigation.PopAsync(); // Navigate back to the previous page (e.g., HomePage)
    }

}

