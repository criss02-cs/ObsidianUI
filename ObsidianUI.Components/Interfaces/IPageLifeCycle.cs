namespace ObsidianUI.Components.Interfaces;

/// <summary>
/// Interface for ViewModel classes that want to implement lifecycle methods for page events.
/// </summary>
/// <remarks>
/// ViewModels implementing this interface can define methods to be called when the associated page is appearing or disappearing.
/// </remarks>
public interface IPageLifeCycle
{
    /// <summary>
    /// Method called when the associated page is appearing.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <remarks>
    /// ViewModel classes implementing this method can perform initialization tasks or refresh data when the page is about to appear.
    /// </remarks>
    Task OnAppearing();
    /// <summary>
    /// Method called when the associated page is disappearing.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <remarks>
    /// ViewModel classes implementing this method can perform cleanup tasks or save data when the page is about to disappear.
    /// </remarks>
    Task OnDisappearing();
}