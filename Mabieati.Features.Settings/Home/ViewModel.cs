using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Mabieati.Features.Settings.Home
{
    internal partial class ViewModel : ObservableObject
    {
        [RelayCommand]
        private void Save()
        {
            Properties.Settings.Default.Save();
        }

        [ObservableProperty]
        private string _language;

        [ObservableProperty]
        private bool _changesSaved;
    }
}
