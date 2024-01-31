using ObsidianUI.Components.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObsidianUI.Examples.ViewModels;

public partial class LifeCyclePageViewModel : ObservableObject, IPageLifeCycle
{
    [ObservableProperty] private bool _isAppearingCalled = false;
    [ObservableProperty] private bool _isDisappearingCalled = false;
    public async Task OnAppearing()
    {
        await Shell.Current.DisplayAlert("Examples", "Appearing is called", "Ok");
        IsAppearingCalled = true;
    }

    public async Task OnDisappearing()
    {
        await Shell.Current.DisplayAlert("Examples", "Disappearing is called", "Ok");
        IsDisappearingCalled = true;
    }
}