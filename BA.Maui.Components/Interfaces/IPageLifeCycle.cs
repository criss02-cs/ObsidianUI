namespace BA.Maui.Components.Interfaces;

/// <summary>
/// Interfaccia da usare su un ViewModel per aggiungergli i life cycle events Appearing e Disappearing
/// </summary>
public interface IPageLifeCycle
{
    Task OnAppearing();
    Task OnDisappearing();
}