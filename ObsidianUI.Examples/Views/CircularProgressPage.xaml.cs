using ObsidianUI.Examples.ViewModels;

namespace ObsidianUI.Examples.Views;

public partial class CircularProgressPage
{
	public CircularProgressPage(CircularProgressPageViewModel vm)
	{
		InitializeComponent();
		txtProgressColor.Text = "240e32";
		txtIncaveColor.Text = "5b237e";

		BindingContext = vm;

		CircularProgress.SetBinding(Components.Controls.CircularProgress.ProgressThicknessProperty, "ProgressThickness");
		CircularProgress.SetBinding(Components.Controls.CircularProgress.ValueProperty, "Value");
	}

	private void TxtProgressColor_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		try
		{
			CircularProgress.ProgressColor = Color.FromArgb($"#{txtProgressColor.Text}");
		}
		catch (Exception)
		{
			CircularProgress.ProgressColor = Color.FromArgb("#240e32");
		}
	}

	private void TxtIncaveColor_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		try
		{
			CircularProgress.ProgressColor = Color.FromArgb($"#{txtIncaveColor.Text}");
		}
		catch (Exception)
		{
			CircularProgress.ProgressColor = Color.FromArgb("#5b237e");
		}
	}
}