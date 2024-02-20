using System.Globalization;
using Microsoft.Maui.Controls.Shapes;

namespace ObsidianUI.Components.Utils;

internal class MonthBuilder(DateTime date, Size dimensions, CultureInfo culture)
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
        if (day.Month != date.Month)
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
    
    private DateTime GetFirstDate(DateTime shownDate)
    {
        var difference = (7 + (shownDate.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek)) % 7;
        return shownDate.AddDays(-1 * difference).Date;
    }


    public MonthBuilder SetHeader()
    {
        _layout.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        _layout.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        _layout.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        var prevButton = new Button
        {
            Text = "Prev"
        };
        var label = GetMonthLabel();
        var nextButton = new Button
        {
            Text = "Next",
            BackgroundColor = Colors.Red
        };
        _layout.Add(prevButton);
        _layout.Add(label, 1);
        _layout.Add(nextButton, 2);
        return this;
    }

    private Label GetMonthLabel()
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var index = firstDayOfMonth.Month - 1;
        var monthName = culture.DateTimeFormat.MonthNames[index];
        var monthLabel = new Label
        {
            Text = $"{char.ToUpper(monthName[0])}{monthName[1..]}",
            // BackgroundColor = Colors.OrangeRed,
            HorizontalTextAlignment = TextAlignment.Center,
            //Margin = new Thickness(10,0,0,0),
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Center
        };
        return monthLabel;
    }

    public MonthBuilder PopulateData()
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var firstDate = GetFirstDate(firstDayOfMonth);
        var addDays = 0;
        for (var i = 0; i < _weeksInAMonth; i++)
        {
            for (var j = 0; j < _daysInAWeek; j++)
            {
                var currentDate = firstDate.AddDays(addDays++);
                _result.Add(GetDay(currentDate), j, i);
            }
        }
        
        
        var firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
        for (var i = 0; i < 7; i++)
        {
            var giorno = culture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
            var label = new Label { Text = $"{char.ToUpper(giorno[0])}{giorno[1..3]}", HorizontalTextAlignment = TextAlignment.Center };
            _header.Add(label, i);
        }

        return this;
    }

    public IView Build()
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