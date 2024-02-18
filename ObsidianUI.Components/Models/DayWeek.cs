namespace ObsidianUI.Components.Models;

public class DayWeek(string name, int columnIndex)
{
    public string Name { get; set; } = name;
    public int ColumnIndex { get; set; } = columnIndex;
}