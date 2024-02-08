using System.Globalization;

namespace ObsidianUI.Components.Controls;

public partial class CalendarView : ContentView
{
    private readonly int _weeksInAMonth = 6;
    private readonly int _daysInAWeek = 7;
    #region BindableProperties

    public static readonly BindableProperty CultureProperty =
        BindableProperty.Create(nameof(Culture), typeof(CultureInfo), typeof(CalendarView), new CultureInfo("en-US"),
            propertyChanged: CulturePropertyChanged);
    public static readonly BindableProperty ShownDateProperty = 
        BindableProperty.Create(nameof(ShownDate), typeof(DateTime), typeof(CalendarView), DateTime.Today,
            propertyChanged: ShownDatePropertyChanged);

    public static readonly BindableProperty OtherMonthDayTextColorProperty =
        BindableProperty.Create(nameof(OtherMonthDayTextColor), typeof(Color), typeof(CalendarView), Colors.Gray);

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

    #endregion

    #region PropertiesChangedEvents

    private static void ShownDatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not CalendarView control) return;
        if (oldvalue is not DateTime old || newvalue is not DateTime newDate) return;
        if (old.Month == newDate.Month && old.Year == newDate.Year) return;
        control.Month.Clear();
        control.Header.Clear();
        control.PopulateGrid();
    }
    private static void CulturePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not CalendarView control) return;
        control.Month.Clear();
        control.Header.Clear();
        control.PopulateGrid();
    }

    #endregion
    public CalendarView()
	{
		InitializeComponent();
		InitializeGrid();
        PopulateGrid();
    }

    private void InitializeGrid()
    {
        var rows = new List<RowDefinition>();
        var width = Application.Current.MainPage.Width;
        var height = Application.Current.MainPage.Height;
        for (var i = 0; i < 5; i++)
        {
            rows.Add(new RowDefinition(height / 5));
        }
        var columns = new List<ColumnDefinition>();
        for (var i = 0; i < 7; i++)
        {
            columns.Add(new ColumnDefinition(width / 7));
        }
        Month.RowDefinitions = new RowDefinitionCollection([.. rows]);
        Month.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
        Header.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
    }

    private void PopulateGrid()
    {
        var firstDate = GetFirstDate(new DateTime(ShownDate.Year, ShownDate.Month, 1));
        var addDays = 0;
        for (var i = 0; i < _weeksInAMonth; i++)
        {
            for(var j = 0; j < _daysInAWeek; j++)
            {
                var currentDate = firstDate.AddDays(addDays++);
                Month.Add(GetDay(currentDate), j, i);
            }
        }

        var firstDayOfWeek = Culture.DateTimeFormat.FirstDayOfWeek;
        for (var i = 0; i < 7; i++)
        {
            var giorno = Culture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
            var label = new Label { Text = giorno[..3] };
            Header.Add(label, i);
        }
    }

    private DateTime GetFirstDate(DateTime shownDate)
    {
        var difference = (7 + (shownDate.DayOfWeek - Culture.DateTimeFormat.FirstDayOfWeek)) % 7;
        return shownDate.AddDays(-1 * difference).Date;
    }

    private StackLayout GetDay(DateTime day)
    {
        var color = Colors.White;
        if (day == DateTime.Today)
            color = Colors.Green;
        if (day.Month != DateTime.Today.Month)
            color = Colors.Gray;
        return new StackLayout
        {
            Children =
            {
                new Label
                {
                    Text = day.Day.ToString(),
                    TextColor = color
                }
            }
        };
    }

    private void CalendarView_OnSizeChanged(object? sender, EventArgs e)
    {
        InitializeGrid();
    }
}