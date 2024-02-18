using System.Globalization;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;

namespace ObsidianUI.Components;

internal class CalendarFactory
{
    private readonly Dictionary<string, ICalendar> _flyweights = [];

    public ICalendar? GetFlyweight(string month)
    {
        if (!_flyweights.TryGetValue(month, out var calendar))
        {
            _flyweights.Add(month, new Month(DateTime.Now, CultureInfo.CurrentCulture));
        }

        return calendar;
    }
}