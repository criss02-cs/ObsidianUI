namespace ObsidianUI.Examples.Views;

public partial class WelcomePage
{
    private bool _alreadyOpen = false;
	public WelcomePage()
	{
		InitializeComponent();
	}


	private void TryOut_Clicked(object? sender, EventArgs e)
    {
#if ANDROID
        if (Shell.Current.FlyoutIsPresented)
        {
            Shell.Current.FlyoutIsPresented = false;
        }
        else
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutIsPresented = true;
        }
#else
        Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
#endif
    }
}