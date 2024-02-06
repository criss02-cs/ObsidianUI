using System.Globalization;

namespace ObsidianUI.Components.Calendar;

public partial class CalendarView : ContentView
{

    #region Properties

    public DateTime ShownDate { get; set; } = DateTime.Today;
    public CultureInfo Culture { get; set; } = new("en-US");
    public Color OtherMonthDayTextColor { get; set; } = Colors.Gray;

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
        var gridLength = new GridLength(150);
        for (var i = 0; i < 5; i++)
        {
            rows.Add(new RowDefinition(gridLength));
        }
        var columns = new List<ColumnDefinition>();
        gridLength = new GridLength(100);
        for (var i = 0; i < 7; i++)
        {
            columns.Add(new ColumnDefinition(gridLength));
        }
        Month.RowDefinitions = new RowDefinitionCollection([.. rows]);
        Month.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
        Header.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
    }

    private void PopulateGrid()
    {
        var daysOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        for (var day = 1; day <= daysOfMonth; day++)
        { 
            var dayDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            var column = (int) dayDateTime.DayOfWeek;
            var row = (int) Math.Ceiling((double)(dayDateTime.Day + (int)firstDayOfMonth.DayOfWeek) / 7);
            Month.Add(GetDay(dayDateTime), column, row - 1);
        }
        // mi prendo i giorni dei mesi precedenti e successivi
        var previousLastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
        // Ottieni il primo giorno della settimana per la cultura specificata
        var firstDayOfWeek = Culture.DateTimeFormat.FirstDayOfWeek;
        var numberOfDayToAdd = Math.Abs((int)firstDayOfMonth.DayOfWeek - (int)firstDayOfWeek);
        for (var i = 1; i <= numberOfDayToAdd; i++)
        {
            var dayDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, previousLastDay);
            var column = (int)dayDateTime.DayOfWeek;
            //var row = (int)Math.Ceiling((double)(dayDateTime.Day + (int)firstDayOfMonth.DayOfWeek) / 7);
            Month.Add(GetDay(dayDateTime), column, 0);
            previousLastDay -= 1;
        }

        var lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, daysOfMonth);
        numberOfDayToAdd = 7 - (int) lastDay.DayOfWeek;
        for (var i = 1; i < numberOfDayToAdd; i++)
        {
            lastDay = lastDay.AddDays(1);
            var column = (int)lastDay.DayOfWeek;
            Month.Add(GetDay(lastDay), column, 4);
        }
        
        for (var i = 0; i < 7; i++)
        {
           var giorno = Culture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
           var label = new Label { Text = giorno[..3] };
           Header.Add(label, i);
        }
    }

    private StackLayout GetDay(DateTime day)
    {
        return new StackLayout
        {
            Children =
            {
                new Label
                {
                    Text = day.Day.ToString(),
                    TextColor = day == DateTime.Today ? Colors.Green : day.Month != DateTime.Today.Month ? Colors.Gray : Colors.White
                }
            }
        };
    }
}