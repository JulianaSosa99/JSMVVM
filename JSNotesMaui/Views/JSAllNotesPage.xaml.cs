namespace JSNotesMaui.Views;

public partial class JSAllNotesPage : ContentPage
{
    public JSAllNotesPage()
    {
        InitializeComponent();
       

    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }

}