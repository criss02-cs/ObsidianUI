using System.Diagnostics;
using System.Globalization;
using Microsoft.Maui.Platform;
using ObsidianUI.Components.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ObsidianUI.Components.Models;

internal class Month : ICalendar
{
    private const int WeeksInAMonth = 5;
    private const int DaysInAWeek = 7;
    public DateTime Date { get; set; }
    public CultureInfo Culture { get; set; }
    public List<Day> Days { get; set; } = [];
    public List<DayWeek> DayWeeks { get; set; } = [];

    private DateTime FirstDayOfMonth => new DateTime(Date.Year, Date.Month, 1);


    public Month(DateTime date, CultureInfo culture)
    {
        Date = date;
        Culture = culture;
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        LoadDays();
        stopwatch.Stop();
        Debug.WriteLine($"Load days duration: {stopwatch.ElapsedMilliseconds}", "Log output");
        stopwatch.Reset();

        stopwatch.Start();
        LoadDaysWeek();
        stopwatch.Stop();
        Debug.WriteLine($"Load days week duration of month {date.Month}: {stopwatch.ElapsedMilliseconds}", "Log output");
    }

    public string GetHeaderString()
    {
        var firstDayOfMonth = new DateTime(Date.Year, Date.Month, 1);
        var index = firstDayOfMonth.Month - 1;
        var monthName = Culture.DateTimeFormat.MonthNames[index];
        return $"{char.ToUpper(monthName[0])}{monthName[1..]}";
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
        var firstDate = GetFirstDate(FirstDayOfMonth);
        var addDays = 0;
        for (var i = 0; i < WeeksInAMonth; i++)
        {
            for (var j = 0; j < DaysInAWeek; j++)
            {
                var currentDate = firstDate.AddDays(addDays++);
                Days.Add(new Day(currentDate, i, j));
            }
        }
    }


    public override bool Equals(object? obj)
    {
        if (obj is not Month m) return false;
        if (ReferenceEquals(this, obj)) return true;
        return m.Date == Date;
    }

    public static bool operator ==(Month m1, Month m2)
    {
        if (ReferenceEquals(m1, m2)) return true;
        if (ReferenceEquals(m1, null)) return false;
        return !ReferenceEquals(m2, null) && m1.Equals(m2);
    }

    public static bool operator !=(Month m1, Month m2) => !(m1 == m2);

    private DateTime GetFirstDate(DateTime shownDate)
    {
        var difference = (7 + (shownDate.DayOfWeek - Culture.DateTimeFormat.FirstDayOfWeek)) % 7;
        return shownDate.AddDays(-1 * difference).Date;
    }
}