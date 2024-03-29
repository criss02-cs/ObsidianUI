﻿global using ObsidianUI.Utils;
global using System;
using Microsoft.Extensions.Logging;
using ObsidianUI.Examples.ViewModels;
using ObsidianUI.Examples.Views;
using UraniumUI;

namespace ObsidianUI.Examples;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterServices()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFontAwesomeIconFonts();
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ThermometerPage>();
        builder.Services.AddSingleton<TermometroPageViewModel>();

        builder.Services.AddSingleton<StarRatingPage>();

        builder.Services.AddSingleton<CircularProgressPage>();
        builder.Services.AddSingleton<CircularProgressPageViewModel>();
        return builder;
    }
}