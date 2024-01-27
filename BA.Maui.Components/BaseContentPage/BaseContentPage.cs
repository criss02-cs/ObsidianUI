using BA.Maui.Components.Interfaces;

namespace BA.Maui.Components.BaseContentPage;

public class BaseContentPage : ContentPage
{
    protected BaseContentPage()
    {
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
    }

    private void OnDisappearing(object? sender, EventArgs e)
    {
        if (BindingContext is not IPageLifeCycle vm) return;
        vm.OnDisappearing();
    }

    private void OnAppearing(object? sender, EventArgs e)
    {
        if (BindingContext is not IPageLifeCycle vm) return;
        vm.OnAppearing();
    }
}