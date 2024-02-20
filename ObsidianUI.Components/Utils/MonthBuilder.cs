using System.Globalization;
using Microsoft.Maui.Controls.Shapes;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;

namespace ObsidianUI.Components.Utils;

internal class MonthBuilder(ICalendar month, CultureInfo culture)
{
    private readonly Grid _result = [];
    private readonly Grid _header = [];
    private readonly Grid _layout = [];
    private const int _weeksInAMonth = 5;
    private const int _daysInAWeek = 7;

    private IView GetDay(DateTime day)
    {
        var color = Colors.White;
        if (day == DateTime.Today)
            color = Colors.Green;
        if (day.Month != month.Date.Month)
            color = Colors.Gray;
        var frame = new Frame
        {
            Content = new Label
            {
                Text = day.Day.ToString(),
                TextColor = color
            },
            CornerRadius = 0,
            BackgroundColor = Colors.Transparent,
            BorderColor = Colors.White,
        };
        return frame;
    }
    public MonthBuilder SetDefinitions()
    {
        var rows = new List<RowDefinition>();
        for (var i = 0; i < 5; i++)
        {
            rows.Add(new RowDefinition(GridLength.Star));
        }
        var columns = new List<ColumnDefinition>();
        for (var i = 0; i < 7; i++)
        {
            columns.Add(new ColumnDefinition(GridLength.Star));
        }
        _result.RowDefinitions = new RowDefinitionCollection([.. rows]);
        _result.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
        _header.ColumnDefinitions = new ColumnDefinitionCollection([.. columns]);
        _header.VerticalOptions = LayoutOptions.Center;
        return this;
    }

    public MonthBuilder PopulateData(List<Day> days, List<DayWeek> dayWeeks) 
    {
        //var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        //var firstDate = GetFirstDate(firstDayOfMonth);
        //var addDays = 0;
        //for (var i = 0; i < _weeksInAMonth; i++)
        //{
        //    for (var j = 0; j < _daysInAWeek; j++)
        //    {
        //        var currentDate = firstDate.AddDays(addDays++);
        //        _result.Add(GetDay(currentDate), j, i);
        //    }
        //}

        foreach (var day in days)
        {
            _result.Add(GetDay(day.Date), day.ColumnIndex, day.RowIndex);
        }

        foreach (var dayWeek in dayWeeks)
        {
            var label = new Label
            {
                Text = $"{char.ToUpper(dayWeek.Name[0])}{dayWeek.Name[1..3]}",
                HorizontalTextAlignment = TextAlignment.Center
            };
            _header.Add(label, dayWeek.ColumnIndex);
        }
        
        
        //var firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
        //for (var i = 0; i < 7; i++)
        //{
        //    var giorno = culture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
        //    var label = new Label { Text = $"{char.ToUpper(giorno[0])}{giorno[1..3]}", HorizontalTextAlignment = TextAlignment.Center };
        //    _header.Add(label, i);
        //}

        return this;
    }

    public View Build()
    {
        var grid = new Grid();
        //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star)});
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star)});
        //grid.Add(_layout);
        grid.Add(_header, 0);
        grid.Add(_result, 0, 1);
        grid.HorizontalOptions = LayoutOptions.Fill;
        return grid;
    }
}