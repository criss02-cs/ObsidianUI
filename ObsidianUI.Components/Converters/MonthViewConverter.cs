using System.Globalization;
using ObsidianUI.Components.Utils;

namespace ObsidianUI.Components.Converters;

public class MonthViewConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        //if (value is not DateTime date) return null;
        //if (date == DateTime.MinValue) return null;
        //if (parameter is not Tuple<Size, CultureInfo> parameters)
        //    parameters = new Tuple<Size, CultureInfo>(new Size(100, 150), new CultureInfo("en-US"));
        //var builder = new MonthBuilder(date, parameters.Item1, parameters.Item2);
        //var result = builder
        //    .SetDefinitions()
        //    .PopulateData()
        //    .Build();
        //return result;
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}