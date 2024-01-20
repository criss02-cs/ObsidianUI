using CommunityToolkit.Mvvm.ComponentModel;

namespace BA.Maui.Examples.ViewModels;

public partial class TermometroPageViewModel : ObservableObject
{
    [ObservableProperty]
    public double temperature = 0d;
    [ObservableProperty]
    public double maxTemperature = 30d;
    [ObservableProperty]
    public int speed = 2000;
}
