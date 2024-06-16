namespace JSNotesMaui.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class JSNotePage : ContentPage

{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public JSNotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JSNote note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");

    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JSNote note)
        {


            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }
        await Shell.Current.GoToAsync("..");
     
    }


    private void LoadNote(string fileName)
    {
        Models.JSNote noteModel= new Models.JSNote();
        noteModel.Filename= fileName;   

      
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }
}