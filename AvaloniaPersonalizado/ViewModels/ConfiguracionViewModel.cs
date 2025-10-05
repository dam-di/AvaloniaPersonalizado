using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaPersonalizado.ViewModels;

public partial class ConfiguracionViewModel:ViewModelBase
{
    [ObservableProperty] private string saludoconfig="Saludo desde Config";
}