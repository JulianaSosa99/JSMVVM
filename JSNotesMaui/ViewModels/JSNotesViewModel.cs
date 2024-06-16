using CommunityToolkit.Mvvm.Input;
using JSNotesMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JSNotesMaui.ViewModels
{
   
    internal class JSNotesViewModel: IQueryAttributable
    {
        public JSNotesViewModel()
        {
            JSAllNotes = new ObservableCollection<ViewModels.JSNoteViewModel>(Models.JSNote.LoadAll().Select(n => new JSNoteViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<ViewModels.JSNoteViewModel>(SelectNoteAsync);
        }

        public ObservableCollection<ViewModels.JSNoteViewModel> JSAllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.JSNotePage));
        }

        private async Task SelectNoteAsync(ViewModels.JSNoteViewModel note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.JSNotePage)}?load={note.JSIdentifier}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
        if (query.ContainsKey("deleted"))
        {
            string noteId = query["deleted"].ToString();
            JSNoteViewModel matchedNote = JSAllNotes.Where((n) => n.JSIdentifier == noteId).FirstOrDefault();

        // If note exists, delete it
        if (matchedNote != null)
            JSAllNotes.Remove(matchedNote);
    }
    else if (query.ContainsKey("saved"))
    {
        string noteId = query["saved"].ToString();
        JSNoteViewModel matchedNote = JSAllNotes.Where((n) => n.JSIdentifier == noteId).FirstOrDefault();

        // If note is found, update it
        if (matchedNote != null)
                {
                    matchedNote.JSReload();
                    JSAllNotes.Move(JSAllNotes.IndexOf(matchedNote), 0);
                }
            

        // If note isn't found, it's new; add it.
        else
                    JSAllNotes.Insert(0, new JSNoteViewModel(Models.JSNote.Load(noteId)));
            }
}

    }
  
}
