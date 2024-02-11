namespace ObsidianUI.Examples.Views;

public partial class WelcomePage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	private void TryOut_Clicked(object? sender, EventArgs e)
	{
		Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
	}
}