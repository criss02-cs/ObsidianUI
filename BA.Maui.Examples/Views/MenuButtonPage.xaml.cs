using BA.Maui.Examples.ViewModels;

namespace BA.Maui.Examples.Views;

public partial class MenuButtonPage : ContentPage
{
	public MenuButtonPage(MenuButtonPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}