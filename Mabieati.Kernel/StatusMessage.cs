using CommunityToolkit.Mvvm.ComponentModel;

namespace Mabieati.Kernel
{
    public partial class StatusMessage : ObservableObject
    {
        [ObservableProperty]
        private State _state;

        [ObservableProperty]
        private string _text;
    }
    public enum State { Success, Error }
}
