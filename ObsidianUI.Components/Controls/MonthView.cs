using System.Globalization;
using ObsidianUI.Components.Converters;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;
using ObsidianUI.Components.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ObsidianUI.Components.Controls;

internal class MonthView : ContentView
{
    private new CalendarView? Parent => base.Parent is CalendarView view ? view : null;
    private CultureInfo CurrentCulture => Parent is not null ? Parent.Culture : new CultureInfo("en-US");

    public static readonly BindableProperty MonthProperty =
        BindableProperty.Create(nameof(Month),
            typeof(Month),
            typeof(MonthView),
            null,
            BindingMode.Default,
            propertyChanged: MonthPropertyChanged);

    private static void MonthPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not MonthView monthView) return;
        monthView.Update();
    }

    public Month? Month
    {
        get => (Month)GetValue(MonthProperty);
        set => SetValue(MonthProperty, value);
    }
    public MonthView()
    {
        Update();
    }

    private void Update()
    {
        if (Month is null) return;
        var result = new MonthBuilder(Month, CurrentCulture)
            .SetDefinitions()
            .PopulateData(Month.Days, Month.DayWeeks)
            .Build();
        Content = result;
    }
}