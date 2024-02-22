using System.Globalization;

namespace ObsidianUI.Components.Interfaces;

public interface ICalendar
{
    public DateTime Date { get; set; }
    public CultureInfo Culture { get; set; }
    string GetHeaderString();
}