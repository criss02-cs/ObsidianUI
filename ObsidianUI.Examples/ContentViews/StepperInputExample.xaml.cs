namespace ObsidianUI.Examples.ContentViews;

public partial class StepperInputExample
{
	public static BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText),
			typeof(string),
			typeof(StepperInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty ValueProperty =
		BindableProperty.Create(nameof(StepperValue),
			typeof(int),
			typeof(StepperInputExample),
			1,
			BindingMode.TwoWay);

	public static BindableProperty MinValueProperty =
		BindableProperty.Create(nameof(MinStepperValue),
			typeof(int),
			typeof(StepperInputExample),
			0,
			BindingMode.TwoWay);

	public static BindableProperty MaxValueProperty =
		BindableProperty.Create(nameof(MaxStepperValue),
			typeof(int),
			typeof(StepperInputExample),
			100,
			BindingMode.TwoWay);

	public int MaxStepperValue
	{
		get => (int)GetValue(MaxValueProperty);
		set => SetValue(MaxValueProperty, value);
	}
	public int MinStepperValue
	{
		get => (int)GetValue(MinValueProperty);
		set => SetValue(MinValueProperty, value);
	}
	public int StepperValue
	{
		get => (int)GetValue(ValueProperty);
		set => SetValue(ValueProperty, value);
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
		if (StepperValue == MaxStepperValue)
			return;

		StepperValue++;
	}
	private void Minus_OnTapped(object? sender, TappedEventArgs e)
	{
		if (StepperValue == MinStepperValue)
			return;

		StepperValue--;
	}
}