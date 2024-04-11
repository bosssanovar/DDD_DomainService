﻿using InMemoryRepository;

using Microsoft.Extensions.DependencyInjection;

using Repository;

using System.Windows;

using UI.MainWindow;
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
            ServiceProvider provider = CreateDependencyInjectionProvider();
            var mainWindow = provider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

        private static ServiceProvider CreateDependencyInjectionProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IAAARepository, AAARepository>();
            services.AddSingleton<IBBBRepository, BBBRepository>();
            services.AddTransient<DisplaySettingsUsecase>();
            services.AddTransient<Model>();
            services.AddTransient<MainWindow>();

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }

}
