using System.Globalization;

namespace ObsidianUI.Components.Interfaces;

internal interface ICalendar
{
    public DateTime Date { get; set; }
    public CultureInfo Culture { get; set; }
}