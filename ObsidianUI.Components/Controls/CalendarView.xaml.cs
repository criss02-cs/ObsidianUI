using System.Globalization;
using Microsoft.Maui.Controls.Shapes;
using ObsidianUI.Components.Interfaces;

namespace ObsidianUI.Components.Controls;

public partial class CalendarView : ContentView
{
    private readonly int _weeksInAMonth = 5;
    private readonly int _daysInAWeek = 7;

    private List<DateTime> _calendars = new List<DateTime>();

    #region BindableProperties

    public readonly BindableProperty CultureProperty =
        BindableProperty.Create(nameof(Culture), typeof(CultureInfo), typeof(CalendarView), new CultureInfo("en-US"),
            propertyChanged: CulturePropertyChanged);
    public readonly BindableProperty ShownDateProperty =
        BindableProperty.Create(nameof(ShownDate), typeof(DateTime), typeof(CalendarView), DateTime.Today,
            propertyChanged: ShownDatePropertyChanged);

    public readonly BindableProperty OtherMonthDayTextColorProperty =
        BindableProperty.Create(nameof(OtherMonthDayTextColor), typeof(Color), typeof(CalendarView), Colors.Gray);

    //public readonly BindableProperty CalendarTypeProperty =
    //    BindableProperty.Create(nameof(CalendarType), typeof(CalendarType), typeof(CalendarView), CalendarType.DAY);

    #endregion

    #region Properties

    public DateTime ShownDate
    {
        get => (DateTime)GetValue(ShownDateProperty);
        set => SetValue(ShownDateProperty, value);
    }

    public CultureInfo Culture
    {
        get => (CultureInfo)GetValue(CultureProperty);
        set => SetValue(CultureProperty, value);
    }

    public Color OtherMonthDayTextColor
    {
        get => (Color)GetValue(OtherMonthDayTextColorProperty);
        set => SetValue(OtherMonthDayTextColorProperty, value);
    }

    //public CalendarType CalendarType
    //{
    //    get => (CalendarType)GetValue(CalendarTypeProperty);
    //    set => SetValue(CalendarTypeProperty, value);
    //}

    #endregion

    #region PropertiesChangedEvents

    private static void ShownDatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not CalendarView control) return;
        if (oldvalue is not DateTime old || newvalue is not DateTime newDate) return;
        if (old.Month == newDate.Month && old.Year == newDate.Year) return;
        control.Update();
    }
    private static void CulturePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not CalendarView control) return;
        control.Update();
    }

    #endregion
    public CalendarView()
    {
        InitializeComponent();
        // Update();
    }

    private void Update()
    {
        _calendars =
        [
            ShownDate.AddMonths(-1),
            ShownDate,
            ShownDate.AddMonths(1),
        ];
        CarouselView.ItemsSource = _calendars;
        CarouselView.ItemTemplate = new DataTemplate(() =>
        {
            var monthView = new MonthView
            {
                WidthRequest = Width - 20,
                HeightRequest = CarouselView.Height - 20,
                Parent = this
            };
            monthView.SetBinding(MonthView.DateProperty, new Binding("."));
            return monthView;
        });
        CarouselView.CurrentItem = ShownDate;
        //CarouselView.ScrollTo(ShownDate, position: ScrollToPosition.Center);
    }

    private void CalendarView_OnSizeChanged(object? sender, EventArgs e)
    {
        Update();
    }

    private void CarouselView_OnCurrentItemChanged(object? sender, CurrentItemChangedEventArgs e)
    {
        if (e.CurrentItem is not DateTime currentDate) return;
        HeaderText.Text = GetMonthName(currentDate);
    }

    private string GetMonthName(DateTime date)
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var index = firstDayOfMonth.Month - 1;
        var monthName = Culture.DateTimeFormat.MonthNames[index];
        return $"{char.ToUpper(monthName[0])}{monthName[1..]}";
    }
}