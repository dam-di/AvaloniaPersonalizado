using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Avalonia.SimpleRouter;
using AvaloniaPersonalizado.ViewModels;
using AvaloniaPersonalizado.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaPersonalizado;

public partial class App : Application
{
    private IServiceProvider? _services;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        _services = ConfigureServices();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            var mainVm = _services.GetRequiredService<MainWindowViewModel>();
            
            

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainVm
            };
        }

        base.OnFrameworkInitializationCompleted();
        OnAppStarted();
    }
    
    private void OnAppStarted()
    {
        // Aquí pones lo que quieras que ocurra al iniciar la app
        ViewModelBase.Router?.GoTo<InicioViewModel>();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Registrar el router global
        services.AddSingleton<HistoryRouter<ViewModelBase>>(sp =>
        {
            var router = new HistoryRouter<ViewModelBase>(
                type => (ViewModelBase)sp.GetRequiredService(type));

            ViewModelBase.ConfigureRouter(router);
            return router;
        });

        // ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<InicioViewModel>();
        services.AddTransient<ConfiguracionViewModel>();

        return services.BuildServiceProvider();
    }
}