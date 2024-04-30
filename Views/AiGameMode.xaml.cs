using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Views;

public partial class AiGameMode : ContentPage
{
    public AiGameMode()
    {
        InitializeComponent();
    }
    
    private async void EndGameButton_Clicked(object sender, EventArgs e)
    {
        // Perform any necessary actions to end the game
        await Navigation.PopAsync(); // Navigate back to the previous page (e.g., HomePage)
    }
}