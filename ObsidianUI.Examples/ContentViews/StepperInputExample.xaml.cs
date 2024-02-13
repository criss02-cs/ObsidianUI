using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ObsidianUI.Examples.ContentViews;

public partial class StepperInputExample
{
	public static BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText),
			typeof(string),
			typeof(StepperInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty StepperValueProperty =
		BindableProperty.Create(nameof(StepperValue),
			typeof(int),
			typeof(StepperInputExample),
			1,
			BindingMode.TwoWay);

	public static BindableProperty MinStepperValueProperty =
		BindableProperty.Create(nameof(MinStepperValue),
			typeof(int),
			typeof(StepperInputExample),
			0,
			BindingMode.TwoWay);

	public static BindableProperty MaxStepperValueProperty =
		BindableProperty.Create(nameof(MaxStepperValue),
			typeof(int),
			typeof(StepperInputExample),
			100,
			BindingMode.TwoWay);

	public event EventHandler<EventArgs> PlusClicked;
	public event EventHandler<EventArgs> MinusClicked;

	public static BindableProperty PlusCommandProperty =
		BindableProperty.Create(nameof(PlusCommand),
			typeof(ICommand),
			typeof(StepperInputExample),null);

	public static BindableProperty MinusCommandProperty =
		BindableProperty.Create(nameof(MinusCommand),
			typeof(ICommand),
			typeof(StepperInputExample), null);

	public ICommand MinusCommand
	{
		get => (ICommand)GetValue(MinusCommandProperty);
		set => SetValue(MinusCommandProperty, value);
	}
	public ICommand PlusCommand
	{
		get => (ICommand)GetValue(PlusCommandProperty);
		set => SetValue(PlusCommandProperty, value);
	}


	public int MaxStepperValue
	{
		get => (int)GetValue(MaxStepperValueProperty);
		set => SetValue(MaxStepperValueProperty, value);
	}
	public int MinStepperValue
	{
		get => (int)GetValue(MinStepperValueProperty);
		set => SetValue(MinStepperValueProperty, value);
	}
	public int StepperValue
	{
		get => (int)GetValue(StepperValueProperty);
		set => SetValue(StepperValueProperty, value);
	}
	public string LabelText
	{
		get => (string)GetValue(LabelTextProperty);
		set => SetValue(LabelTextProperty, value);
	}

	public StepperInputExample()
	{
		InitializeComponent();
	}

	private void Plus_OnTapped(object? sender, TappedEventArgs e)
	{
		PlusClicked?.Invoke(sender, e);
		
		if (StepperValue == MaxStepperValue)
			return;

		StepperValue++;
	}
	private void Minus_OnTapped(object? sender, TappedEventArgs e)
	{
		MinusClicked?.Invoke(sender,e);

		if (StepperValue == MinStepperValue)
			return;

		StepperValue--;
		
	}
}