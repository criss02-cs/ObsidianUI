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
            DateTime.Now.Date,
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

    private void Update()
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

    internal event EventHandler? SizeChanged;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (HeightRequest == -1 || WidthRequest == -1) return;
        var rowHeight = HeightRequest * 0.8 / 5;
        var columnWidth = WidthRequest / 7;
        if (!Children.Any()) return;
        if (Children[0] is not StackLayout layout) return;
        foreach (var child in layout.Children)
        {
            if (child is StackLayout stackLayout) stackLayout.HeightRequest = HeightRequest * 0.2;
            if (child is not Grid grid) continue;
            foreach (var columnDefinition in grid.ColumnDefinitions)
            {
                columnDefinition.Width = columnWidth;
            }
        
            if (grid.RowDefinitions.Count <= 1) continue;
            grid.HeightRequest = HeightRequest * 0.8;
            foreach (var rowDefinition in grid.RowDefinitions)
            {
                rowDefinition.Height = rowHeight;
            }
        }
        SizeChanged?.Invoke(this, EventArgs.Empty);
    }
}