using Microsoft.Maui;
using Microsoft.Maui.Controls;
using ObsidianUI.Examples.ContentViews;
using ObsidianUI.Examples.ViewModels;

namespace ObsidianUI.Examples.Views;

public partial class CircularProgressPage
{
	private CircularProgressPageViewModel ViewModel => (CircularProgressPageViewModel)BindingContext;

	public CircularProgressPage(CircularProgressPageViewModel vm)
	{
		InitializeComponent();
		
		BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		ViewModel.Speed = 1;
		ViewModel.MaxValue = 100;
		ViewModel.Value = 50;
		ViewModel.ProgressThickness = 18;
		ViewModel.ProgressColor = ColorProgress.Color;
		ViewModel.LineCap = LineCap.Round;

		StepperSpeed.StepperValue = 1;
		StepperMaxValue.StepperValue = 100;
		StepperValue.StepperValue = 50;
		StepperProgressThickness.StepperValue = 18;
		PickerLineCap.SelectedItem = LineCap.Round;

		CircularProgress.Start();
		base.OnAppearing();
	}

	private void Stepper_OnPlusMinusClicked(object? sender, EventArgs e)
	{
		if (sender is not StepperInputExample stepper)
			return;

		if (stepper == StepperSpeed)
		{
			ViewModel.Speed = stepper.StepperValue;
		}
		else if (stepper == StepperMaxValue)
		{
			ViewModel.MaxValue = stepper.StepperValue;
		}
		else if (stepper == StepperValue)
		{
			ViewModel.Value = stepper.StepperValue;
		}
		else if (stepper == StepperProgressThickness)
		{
			ViewModel.ProgressThickness = stepper.StepperValue;
		}
	}

	private void ColorProgress_OnColorChanged(object? sender, EventArgs e)
	{
		ViewModel.ProgressColor = ColorProgress.Color;
	}

	private void PickerLineCap_OnSelectedIndexChanged(object? sender, EventArgs e)
	{
		if (PickerLineCap.SelectedItem is LineCap linecap)
		{
			ViewModel.LineCap = linecap;
		}
	}
}