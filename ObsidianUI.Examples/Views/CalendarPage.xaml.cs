using System.Globalization;

namespace ObsidianUI.Examples.Views;

public partial class CalendarPage : ContentPage
{
	public CultureInfo CultureP { get; set; } = new CultureInfo("it-IT");
	public CalendarPage()
	{
		InitializeComponent();
		BindingContext = this;
		// View.SetValue(View.CultureProperty, CultureP);
	}
}