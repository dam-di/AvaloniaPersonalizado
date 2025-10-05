using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaPersonalizado.ViewModels;

public class ViewModelBase : ObservableObject
{
    public static HistoryRouter<ViewModelBase>? Router { get; private set; }

    public static void ConfigureRouter(HistoryRouter<ViewModelBase> router)
    {
        Router = router;
    }

    protected void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        Router?.GoTo<TViewModel>();
    }

    protected void GoBack() => Router?.Back();
    protected void GoForward() => Router?.Forward();
}