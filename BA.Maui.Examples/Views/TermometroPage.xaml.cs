using BA.Maui.Examples.ViewModels;

namespace BA.Maui.Examples.Views;

public partial class TermometroPage : ContentPage
{
	public TermometroPage(TermometroPageViewModel vm)
	{
		InitializeComponent();
        txtTempColor.Text = "ff0000";
        txtBorderColor.Text = "333";
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
            termometro.TemperaturaColor = Color.FromArgb($"#ff0000");
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
            termometro.BorderColor = Color.FromArgb($"#333");
        }
    }
}