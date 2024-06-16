namespace JSNotesMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {

            InitializeComponent();


            Routing.RegisterRoute(nameof(Views.JSNotePage), typeof(Views.JSNotePage));

        }
    }
}
