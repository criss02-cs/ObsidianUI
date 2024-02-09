using System.Globalization;
using ObsidianUI.Components.Interfaces;

namespace ObsidianUI.Components.Controls;

public partial class MonthView : ContentView, ICalendarView
{
    private readonly int _weeksInAMonth = 5;
    private readonly int _daysInAWeek = 7;
    private DateTime _date;
    private CalendarView? _parent => Parent is CalendarView view ? view : null;
    private CultureInfo _currentCulture => _parent is not null ? _parent.Culture : new CultureInfo("en-US");
	public MonthView(DateTime date)
	{
		InitializeComponent();
        _date = date;
    }

    public void RenderView()
    {
        InitializeGrid();
        PopulateGrid();
    }

    private void InitializeGrid()
    {
        Month.Clear();
        Header.Clear();
        var rows = new List<RowDefinition>();
        var width = Width;
        var height = Height;
        if (width == -1) width = 100;
        if (height == -1) height = 150;
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
        var firstDate = GetFirstDate(new DateTime(_date.Year, _date.Month, 1));
        var addDays = 0;
        for (var i = 0; i < _weeksInAMonth; i++)
        {
            for (var j = 0; j < _daysInAWeek; j++)
            {
                var currentDate = firstDate.AddDays(addDays++);
                Month.Add(GetDay(currentDate), j, i);
            }
        }

        var firstDayOfWeek = _currentCulture.DateTimeFormat.FirstDayOfWeek;
        for (var i = 0; i < 7; i++)
        {
            var giorno = _currentCulture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
            var label = new Label { Text = giorno[..3] };
            Header.Add(label, i);
        }
    }

    private DateTime GetFirstDate(DateTime shownDate)
    {
        var difference = (7 + (shownDate.DayOfWeek - _currentCulture.DateTimeFormat.FirstDayOfWeek)) % 7;
        return shownDate.AddDays(-1 * difference).Date;
    }

    private IView GetDay(DateTime day)
    {
        var color = Colors.White;
        if (day == DateTime.Today)
            color = Colors.Green;
        if (day.Month != DateTime.Today.Month)
            color = Colors.Gray;
        var frame = new Frame()
        {
            Content = new Label
            {
                Text = day.Day.ToString(),
                TextColor = color
            },
            CornerRadius = 0,
            BackgroundColor = Colors.Transparent,
            BorderColor = Colors.White
        };
        return frame;
    }
}