namespace ObsidianUI.Components.Models;

internal class Day(DateTime date, int rowIndex, int columnIndex)
{
    public DateTime Date { get; set; } = date;
    public int RowIndex { get; set; } = rowIndex;
    public int ColumnIndex { get; set; } = columnIndex;
}