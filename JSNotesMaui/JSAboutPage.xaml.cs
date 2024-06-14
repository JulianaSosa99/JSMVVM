namespace JSNotesMaui;

public partial class JSAboutPage : ContentPage
{
	public JSAboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {

        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}