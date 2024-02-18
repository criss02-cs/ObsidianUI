using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Hosting;

namespace ObsidianUI;

public static class FontAwesomeConfigurationExtensions
{
    public static IFontCollection AddFontAwesomeIcons(this IFontCollection fonts)
    {
        fonts.AddEmbeddedResourceFont(
            typeof(FontAwesomeConfigurationExtensions).Assembly,
            filename: "fa-solid-900.ttf",
            alias: "FaSolid");
        fonts.AddEmbeddedResourceFont(
            typeof(FontAwesomeConfigurationExtensions).Assembly,
            filename: "fa-brands-900.ttf",
            alias: "FaBrand");

        return fonts;
    }
}
