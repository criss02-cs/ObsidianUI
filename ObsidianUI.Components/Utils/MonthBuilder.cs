using System.Globalization;
using Microsoft.Maui.Controls.Shapes;
using ObsidianUI.Components.Controls;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;

namespace ObsidianUI.Components.Utils;

internal class MonthBuilder(ICalendar month, CultureInfo culture)
{
    private readonly Grid _result = [];
    private readonly Grid _header = [];
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
        foreach (var day in days)
        {
            var color = Colors.White;
            if (day.Date == DateTime.Now) color = Colors.Green;
            if (day.Date.Month != month.Date.Month) color = Colors.Gray;
            _result.Add(new MonthDayView(day, color), day.ColumnIndex, day.RowIndex);
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
        return this;
    }

    public View Build()
    {
        var grid = new Grid();
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star)});
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star)});
        grid.Add(_header, 0);
        grid.Add(_result, 0, 1);
        grid.HorizontalOptions = LayoutOptions.Fill;
        return grid;
    }
}