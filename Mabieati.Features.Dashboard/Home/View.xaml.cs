using System.Windows;

namespace Mabieati.Features.Dashboard.Home
{
    internal partial class View : Window, IDashboardView
    {
        public View(ViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
