using CommunityToolkit.Mvvm.ComponentModel;

namespace ObsidianUI.Examples.ViewModels;

public partial class CircularProgressPageViewModel : ObservableObject
{
    [ObservableProperty] public Color incaveColor;
    [ObservableProperty] public Color progressColor;
    [ObservableProperty] public int cornerRadius;
    [ObservableProperty] public int value;
    [ObservableProperty] public int maxValue;
    [ObservableProperty] public int progressThickness;
    [ObservableProperty] public int speed;
    [ObservableProperty] public LineCap lineCap;
    [ObservableProperty] public string text;

}