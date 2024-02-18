using ObsidianUI.Components.Interfaces;

namespace ObsidianUI.Components.BaseContentPage;

/// <summary>
/// Base class for content pages.
/// </summary>
/// <remarks>
/// This class extends <see cref="ContentPage"/> and adds event handlers for the appearing and disappearing events of the page.
/// It automatically associates with ViewModels that implement the <see cref="IPageLifeCycle"/> interface.
/// </remarks>
public class BaseContentPage : ContentPage
{
    protected BaseContentPage()
    {
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
    }

    /// <summary>
    /// Handles the disappearing event of the page.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void OnDisappearing(object? sender, EventArgs e)
    {
        if (BindingContext is not IPageLifeCycle vm) return;
        vm.OnDisappearing();
    }

    /// <summary>
    /// Handles the appearing event of the page.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void OnAppearing(object? sender, EventArgs e)
    {
        if (BindingContext is not IPageLifeCycle vm) return;
        vm.OnAppearing();
    }
}