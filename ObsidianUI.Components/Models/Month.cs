using System.Globalization;
using ObsidianUI.Components.Interfaces;

namespace ObsidianUI.Components.Models;

internal class Month : ICalendar
{
    private const int _weeksInAMonth = 5;
    private const int _daysInAWeek = 7;
    public DateTime Date { get; set; }
    public CultureInfo Culture { get; set; }
    public List<Day> Days { get; set; } = [];
    public List<DayWeek> DayWeeks { get; set; } = [];


    public Month(DateTime date, CultureInfo culture)
    {
        Date = date;
        Culture = culture;
        LoadDays();
        LoadDaysWeek();
    }

    private void LoadDaysWeek()
    {
        var firstDayOfWeek = Culture.DateTimeFormat.FirstDayOfWeek;
        for (var i = 0; i < 7; i++)
        {
            var giorno = Culture.DateTimeFormat.DayNames[((int)firstDayOfWeek + i) % 7];
            DayWeeks.Add(new DayWeek(giorno[..3], i));
        }
    }

    private void LoadDays()
    {
        var firstDate = GetFirstDate(Date);
        var addDays = 0;
        for (var i = 0; i < _weeksInAMonth; i++)
        {
            for (var j = 0; j < _daysInAWeek; j++)
            {
                var currentDate = firstDate.AddDays(addDays++);
                Days.Add(new Day(currentDate.Day, i, j));
            }
        }
    }
    private DateTime GetFirstDate(DateTime showDate)
    {
        var difference = (7 + (showDate.DayOfWeek - Culture.DateTimeFormat.FirstDayOfWeek)) % 7;
        return showDate.AddDays(-1 * difference).Date;
    }
}