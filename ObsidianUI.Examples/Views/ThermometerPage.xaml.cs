using ObsidianUI.Examples.ViewModels;

namespace ObsidianUI.Examples.Views;

public partial class ThermometerPage : BaseComponentPage
{
	public ThermometerPage(TermometroPageViewModel vm)
	{
		InitializeComponent();
        txtTempColor.Text = "240e32";
        txtBorderColor.Text = "5b237e";
		BindingContext = vm;
	}

    private void TemperaturaColor_TextChange(object sender, TextChangedEventArgs e)
    {
		try
		{
            termometro.TemperaturaColor = Color.FromArgb($"#{txtTempColor.Text}");
        }
        catch (Exception)
        {
            termometro.TemperaturaColor = Color.FromArgb("#240e32");
        }
    }

    private void BorderColor_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
            termometro.BorderColor = Color.FromArgb($"#{txtBorderColor.Text}");
        }
        catch (Exception)
		{
            termometro.BorderColor = Color.FromArgb("#5b237e");
        }
    }
}