using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

    [RelayCommand]
    private void AddThickness()
    {
        ProgressThickness++;
    }

    [RelayCommand]
    private void RemoveThickness()
    {
        ProgressThickness--;
    }
}