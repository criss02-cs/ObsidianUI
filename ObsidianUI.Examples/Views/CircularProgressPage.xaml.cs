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
		//txtProgressColor.Text = "5b237e";
		//txtIncaveColor.Text = "000000";
		//StepperSpeed.Value = 1;
		//StepperValue.Value = 50;
		//StepperMaxValue.Value = 100;
		//StepperProgressThickness.Value = 18;
		//txtText.Text = "Circular progress";

		CircularProgress.Start();
		base.OnAppearing();
	}
}