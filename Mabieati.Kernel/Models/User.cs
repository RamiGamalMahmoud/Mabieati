using CommunityToolkit.Mvvm.ComponentModel;

namespace Mabieati.Kernel.Models
{
    public partial class User : ObservableValidator
    {
        private User()
        {
        }

        public User(string userName, string fullName)
        {
            UserName = userName;
            FullName = fullName;
        }
        public int Id { get; private set; }

        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _fullName;
    }
}
