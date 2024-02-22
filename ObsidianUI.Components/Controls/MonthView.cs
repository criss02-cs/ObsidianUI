using System.Diagnostics;
using System.Globalization;
using ObsidianUI.Components.Converters;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;
using ObsidianUI.Components.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ObsidianUI.Components.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
internal class MonthView : ContentView
{
    private new CalendarView? Parent => base.Parent as CalendarView;
    private CultureInfo CurrentCulture => Parent is not null ? Parent.Culture : new CultureInfo("en-US");

    public static readonly BindableProperty MonthProperty =
        BindableProperty.Create(nameof(Month),
            typeof(Month),
            typeof(MonthView),
            null,
            BindingMode.Default,
            propertyChanged: MonthPropertyChanged);

    private bool isBusy = false;

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
        //Update();
        SetBinding(MonthProperty, new Binding("."));
#if ANDROID || IOS
        Margin = new Thickness(0);
#else
        Margin = new Thickness(20, 20);
#endif
    }

    private void Update()
    {
        if (Month is null) return;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = new MonthBuilder(Month, Month.Culture)
            .SetDefinitions()
            .PopulateData(Month.Days, Month.DayWeeks)
            .Build();
        Debug.WriteLine($"Before load user interface: {stopwatch.ElapsedMilliseconds}");
        Content = result;
        stopwatch.Stop();
        Debug.WriteLine($"Load user interface of date {Month.Date.Month}: {stopwatch.ElapsedMilliseconds}");
    }
}