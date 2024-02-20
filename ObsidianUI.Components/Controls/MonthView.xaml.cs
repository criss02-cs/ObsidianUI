using System.Globalization;
using ObsidianUI.Components.Converters;
using ObsidianUI.Components.Interfaces;

namespace ObsidianUI.Components.Controls;

public partial class MonthView : ContentView
{
    private CalendarView? _parent => Parent is CalendarView view ? view : null;
    private CultureInfo _currentCulture => _parent is not null ? _parent.Culture : new CultureInfo("en-US");

    public static readonly BindableProperty DateProperty =
        BindableProperty.Create(nameof(Date),
            typeof(DateTime),
            typeof(MonthView),
            null,
            BindingMode.Default,
            propertyChanged: DatePropertyChanged);

    private static void DatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not MonthView monthView) return;
        monthView.Update();
    }

    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }
	public MonthView()
	{
		InitializeComponent();
        Update();
    }

    public void Update()
    {
        var binding = new Binding
        {
            Source = this,
            Path = nameof(Date),
            Converter = new MonthViewConverter(),
            ConverterParameter = new Tuple<Size, CultureInfo>(new Size(WidthRequest, HeightRequest), _currentCulture)
        };
        SetBinding(ContentProperty, binding);
    }
}