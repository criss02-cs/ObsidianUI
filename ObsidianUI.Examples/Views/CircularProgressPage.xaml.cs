using ObsidianUI.Examples.ViewModels;

namespace ObsidianUI.Examples.Views;

public partial class CircularProgressPage
{
	public CircularProgressPage(CircularProgressPageViewModel vm)
	{
		InitializeComponent();
		
		BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		txtProgressColor.Text = "5b237e";
		txtIncaveColor.Text = "000000";
		StepperSpeed.Value = 1;
		StepperValue.Value = 50;
		StepperMaxValue.Value = 100;
		StepperProgressThickness.Value = 18;
		txtText.Text = "Circular progress";

		CircularProgress.Start();
		base.OnAppearing();
	}

	private void TxtProgressColor_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		try
		{
			CircularProgress.ProgressColor = Color.FromArgb($"#{txtProgressColor.Text}");
		}
		catch (Exception)
		{
			CircularProgress.ProgressColor = Color.FromArgb("#5b237e");
		}
	}

	private void TxtIncaveColor_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		try
		{
			CircularProgress.IncaveColor = Color.FromArgb($"#{txtIncaveColor.Text}");
		}
		catch (Exception)
		{
			CircularProgress.IncaveColor = Color.FromArgb("#000000");
		}
	}
}