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
	public event EventHandler<EventArgs> ColorChanged;
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

	private void RgbColorPicker_OnColorChanged(object? sender, EventArgs e)
	{
		var rgb = ColorPicker.Rgb.Replace("(", "").Replace(")", "");
		var rgbSpit = rgb.Split(",");
		var r = rgbSpit[0];
		var g = rgbSpit[1];
		var b = rgbSpit[2];
		Color = new Color(r.ToInt32(), g.ToInt32(), b.ToInt32());
		ColorChanged?.Invoke(sender,e);
	}
}