using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsidianUI.Examples.ViewModels;

public partial class TermometroPageViewModel : ObservableObject
{
    [ObservableProperty]
    public double temperature = 0d;
    [ObservableProperty]
    public double maxTemperature = 30d;
    [ObservableProperty]
    public int speed = 2000;
}
