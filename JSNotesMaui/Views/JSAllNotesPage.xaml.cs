namespace JSNotesMaui.Views;

public partial class JSAllNotesPage : ContentPage
{
    public JSAllNotesPage()
    {
        InitializeComponent();
        BindingContext = new Models.JSAllNotes();

    }
    protected override void OnAppearing()
    {
        ((Models.JSAllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JSNotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.JSNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"

            await Shell.Current.GoToAsync($"{nameof(JSNotePage)}?{nameof(JSNotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }



}