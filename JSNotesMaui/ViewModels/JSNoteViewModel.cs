using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSNotesMaui.ViewModels
{
    internal class JSNoteViewModel : ObservableObject, IQueryAttributable

    {
        public JSNoteViewModel()
        {
            _jsnote = new Models.JSNote();
            JSSaveCommand = new AsyncRelayCommand(JSSave);
            JSDeleteCommand = new AsyncRelayCommand(JSDelete);
        }
        public JSNoteViewModel(Models.JSNote note)
        {
            _jsnote = note;
            JSSaveCommand = new AsyncRelayCommand(JSSave);
            JSDeleteCommand = new AsyncRelayCommand(JSDelete);
        }
        private async Task JSSave()
        {
            _jsnote.Date = DateTime.Now;
            _jsnote.JSSave();
            await Shell.Current.GoToAsync($"..?saved={_jsnote.Filename}");
        }

        private async Task JSDelete()
        {
            _jsnote.JSDelete();
            await Shell.Current.GoToAsync($"..?deleted={_jsnote.Filename}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _jsnote = Models.JSNote.Load(query["load"].ToString());
                JSRefreshProperties();
            }
        }
        public void JSReload()
        {
            _jsnote = Models.JSNote.Load(_jsnote.Filename);
            JSRefreshProperties();
        }

        private void JSRefreshProperties()
        {
            OnPropertyChanged(nameof(JSText));
            OnPropertyChanged(nameof(JSDate));
        }

        private Models.JSNote _jsnote;

        public string JSText
        {
            get => _jsnote.Text;
            set
            {
                if (_jsnote.Text != value)
                {
                    _jsnote.Text = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand JSSaveCommand { get; private set; }
        public ICommand JSDeleteCommand { get; private set; }

        public DateTime JSDate => _jsnote.Date;

        public string JSIdentifier => _jsnote.Filename;
    }

}
