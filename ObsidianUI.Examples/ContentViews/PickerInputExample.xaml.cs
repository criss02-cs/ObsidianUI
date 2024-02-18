using System.Collections;

namespace ObsidianUI.Examples.ContentViews;

public partial class PickerInputExample
{

	public static BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText),
			typeof(string),
			typeof(PickerInputExample),
			string.Empty,
			BindingMode.TwoWay);

	public static BindableProperty ItemSourceProperty =
		BindableProperty.Create(nameof(ItemSource),
			typeof(IList),
			typeof(PickerInputExample),
			default(IList),
			BindingMode.TwoWay);

	public static BindableProperty SelectedItemProperty =
		BindableProperty.Create(nameof(SelectedItem),
			typeof(object),
			typeof(PickerInputExample),
			null,
			BindingMode.TwoWay);

	public event EventHandler<EventArgs> SelectedIndexChanged;
	public object SelectedItem
	{
		get => (object)GetValue(SelectedItemProperty);
		set => SetValue(SelectedItemProperty, value);
	}
	public IList ItemSource
	{
		get => (IList)GetValue(ItemSourceProperty);
		set => SetValue(ItemSourceProperty, value);
	}
	public string LabelText
	{
		get => (string)GetValue(LabelTextProperty);
		set => SetValue(LabelTextProperty, value);
	}

	public PickerInputExample()
	{
		InitializeComponent();
	}

	private void PickerLineCap_OnSelectedIndexChanged(object? sender, EventArgs e)
	{
		SelectedIndexChanged?.Invoke(this,e);
	}
}