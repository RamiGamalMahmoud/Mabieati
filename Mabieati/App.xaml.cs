using CommunityToolkit.Mvvm.Messaging;
using Mabieati.Data;
using Mabieati.Features.Auth;
using Mabieati.Features.Auth.Login;
using Mabieati.Features.Dashboard;
using Mabieati.Features.Dashboard.Home;
using Mabieati.Kernel.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Threading;
using Mabieati.Features.UsersManagement;
using System.Windows;
using System.Windows.Markup;
using Velopack;
using System.Threading.Tasks;

namespace Mabieati
{
    public partial class App : Application
    {
        public App()
        {
            VelopackApp.Build().Run();
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
                    services.ConfigureDataService();
                    services.ConfigureAuthFeature();
                    services.ConfigureDashboardFeature();
                    services.ConfigureUsersManagementFeature();
                })
                .Build();
            SetLanguage();

            WeakReferenceMessenger.Default.Register<UserLoggedInMessage>(this, (r, m) => ShowDashboard(m));
        }

        private static async Task UpdateApp()
        {
            UpdateManager updateManager = new UpdateManager("https://github.com/RamiGamalMahmoud/Mabieati");
            UpdateInfo updateInfo = await updateManager.CheckForUpdatesAsync();
            if (updateInfo is null)
                return;
            await updateManager.DownloadUpdatesAsync(updateInfo);
            updateManager.ApplyUpdatesAndRestart(updateInfo);
        }

        private void ShowDashboard(UserLoggedInMessage m)
        {
            Window dashboard = _host.Services.GetRequiredService<IDashboardView>() as Window;
            Window loginWindow = MainWindow;
            MainWindow = dashboard;
            loginWindow.Close();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
#if !DEBUG
            await UpdateApp();
#endif
            MainWindow = (Window)_host.Services.GetRequiredService<ILoginView>();
            MainWindow.Show();
            await _host.RunAsync();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            base.OnExit(e);
        }

        private void SetLanguage()
        {
            //var langViewModel = _host.Services.GetRequiredService<ISettingsViewModel>();
            //var vCulture = new CultureInfo(langViewModel.Language);
            var vCulture = new CultureInfo("en");

            Thread.CurrentThread.CurrentCulture = vCulture;
            Thread.CurrentThread.CurrentUICulture = vCulture;
            CultureInfo.DefaultThreadCurrentCulture = vCulture;
            CultureInfo.DefaultThreadCurrentUICulture = vCulture;

            FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        private readonly IHost _host;
    }
}
