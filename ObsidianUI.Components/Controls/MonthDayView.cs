using ObsidianUI.Components.Models;

namespace ObsidianUI.Components.Controls;

internal class MonthDayView : ContentView
{
	public MonthDayView(Day day, Color textColor)
    {
        Content = LoadDay(day, textColor);
    }

    private static Frame LoadDay(Day day, Color textColor)
    {
        try
        {
            var frame = new Frame
            {
                Content = new Label
                {
                    Text = day.Date.Day.ToString(),
#if ANDROID || IOS
                    Margin = new Thickness(2, 0),
                    HorizontalTextAlignment = TextAlignment.Center,
#endif
                    TextColor = textColor
                },
                CornerRadius = 0,
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.White,
            };
            return frame;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}