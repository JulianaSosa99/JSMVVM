using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JSNotesMaui.ViewModels
{
    internal class JSAboutViewModel
    {
        public string JSTitle => AppInfo.Name;
        public string JSVersion => AppInfo.VersionString;
        public string JSMoreInfoUrl => "https://aka.ms/maui";
        public string JSMessage => "This app is written in XAML and C# with .NET MAUI. POR JULIANA SOSA";
        public ICommand ShowMoreInfoCommand { get; }

        public JSAboutViewModel()
        {
            ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(JSMoreInfoUrl);
    }
}
