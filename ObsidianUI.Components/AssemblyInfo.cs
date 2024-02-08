[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(ObsidianUI.Components.Controls))]
[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "obsComponents")]

internal static class Constants
{
    public const string XamlNamespace = "http://schemas.enisn-projects.io/dotnet/maui/obsidianui/components";

    public const string NamespacePrefix = $"{nameof(ObsidianUI)}.{nameof(ObsidianUI.Components)}.";
}