namespace ObsidianUI.Examples.ContentViews;

public partial class ColorInputExample
{
	public static BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText),
			typeof(string),
			typeof(EntryInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty ColorProperty =
		BindableProperty.Create(nameof(Color),
			typeof(Color),
			typeof(ColorInputExample),
			Colors.Purple,
			BindingMode.TwoWay);

	public string LabelText
	{
		get => (string)GetValue(LabelTextProperty);
		set => SetValue(LabelTextProperty, value);
	}
	public Color Color
	{
		get => (Color)GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}

	public ColorInputExample()
	{
		InitializeComponent();
	}
}