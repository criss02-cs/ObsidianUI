namespace ObsidianUI.Components.Models;

internal class Day(int number, int rowIndex, int columnIndex)
{
    public int Number { get; set; } = number;
    public int RowIndex { get; set; } = rowIndex;
    public int ColumnIndex { get; set; } = columnIndex;
}