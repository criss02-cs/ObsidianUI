using System.Globalization;
using Microsoft.Maui.Controls.Shapes;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;

namespace ObsidianUI.Components.Controls;

public partial class CalendarView : ContentView
{
    private readonly int _weeksInAMonth = 5;
    private readonly int _daysInAWeek = 7;

    private List<ICalendar> _calendars = [];

    //private List<DateTime> _calendars = [];

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
        var actual = new Month(ShownDate, Culture);
        _calendars =
        [
            new Month(ShownDate.AddMonths(-1), Culture),
            actual,
            new Month(ShownDate.AddMonths(1), Culture),
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
            monthView.SetBinding(MonthView.MonthProperty, new Binding("."));
            return monthView;
        });
        CarouselView.CurrentItem = actual;
        //CarouselView.ScrollTo(ShownDate, position: ScrollToPosition.Center);
    }

    private void CalendarView_OnSizeChanged(object? sender, EventArgs e)
    {
        Update();
    }

    private void CarouselView_OnCurrentItemChanged(object? sender, CurrentItemChangedEventArgs e)
    {
        if (e.CurrentItem is not ICalendar currentDate) return;
        HeaderText.Text = currentDate.GetHeaderString();
    }

    private string GetMonthName(DateTime date)
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var index = firstDayOfMonth.Month - 1;
        var monthName = Culture.DateTimeFormat.MonthNames[index];
        return $"{char.ToUpper(monthName[0])}{monthName[1..]}";
    }

    private void Button_OnPressed(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        var index = _calendars.IndexOf((ICalendar)CarouselView.CurrentItem);
        if (button == PrevButton)
        {
            CarouselView.ScrollTo(index - 1);
        }
        else
        {
            CarouselView.ScrollTo(index + 1);
        }
    }
}