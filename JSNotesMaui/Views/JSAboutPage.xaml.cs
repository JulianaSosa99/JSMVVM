namespace JSNotesMaui.Views;

public partial class JSAboutPage : ContentPage
{
	public JSAboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        //creacion del boton LeanMoreClicked
        if (BindingContext is Models.JSAbout about)
        {
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);


        }


    }

}