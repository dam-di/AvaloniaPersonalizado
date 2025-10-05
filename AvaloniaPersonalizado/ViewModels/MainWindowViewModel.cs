using Avalonia.SimpleRouter;
using AvaloniaPersonalizado.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace AvaloniaPersonalizado.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private object? currentView;
    
    [ObservableProperty]
    private object? selectedItem;
    public MainWindowViewModel(HistoryRouter<ViewModelBase> router)
    {
        // Aquí enganchamos el router para actualizar Content
        router.CurrentViewModelChanged += vm => CurrentView = vm;

        // Registrar router en la base
        ConfigureRouter(router);

        // Vista inicial
        router.GoTo<InicioViewModel>();
    }

    partial void OnSelectedItemChanged(object value)
    {

        NavigationViewItem item = (NavigationViewItem)value;
        if (item.Content.Equals("Inicio"))
        {
            //CurrentView = new InicioView();
            NavigateTo<InicioViewModel>();
            
        }
        else
        {
            NavigateTo<ConfiguracionViewModel>();
            //CurrentView = new ConfiguracionView();
        }
    }

}