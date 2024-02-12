namespace ObsidianUI.Examples.ContentViews;

public partial class EntryInputExample
{
	public static BindableProperty EntryTextProperty =
		BindableProperty.Create(nameof(EntryText),
			typeof(string),
			typeof(EntryInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText),
			typeof(string),
			typeof(EntryInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty KeyBoardProperty =
		BindableProperty.Create(nameof(KeyBoard),
			typeof(Keyboard),
			typeof(EntryInputExample),
			Keyboard.Default,
			BindingMode.TwoWay);

	public Keyboard KeyBoard
	{
		get => (Keyboard)GetValue(KeyBoardProperty);
		set => SetValue(KeyBoardProperty, value);
	}
	public string EntryText
	{
		get => (string)GetValue(EntryTextProperty);
		set => SetValue(EntryTextProperty, value);
	}
	public string LabelText
	{
		get => (string)GetValue(LabelTextProperty);
		set => SetValue(LabelTextProperty, value);
	}

	public EntryInputExample()
	{
		InitializeComponent();
	}
}