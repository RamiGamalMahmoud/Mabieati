using System.Windows;

namespace Mabieati.Features.Auth.Login
{
    internal partial class View : Window, ILoginView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
