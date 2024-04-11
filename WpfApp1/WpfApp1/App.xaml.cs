using Microsoft.Extensions.DependencyInjection;

using Repository;

using System.Windows;

using Usecase;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddSingleton<AAARepository>();
            services.AddSingleton<BBBRepository>();
            services.AddTransient<DisplaySettingsUsecase>();
            services.AddTransient<Model>();
            services.AddTransient<MainWindow>();

            var provider = services.BuildServiceProvider();
            var mainWindow = provider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
    }

}
