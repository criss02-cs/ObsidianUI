using CommunityToolkit.Mvvm.ComponentModel;
using ObsidianUI.Examples.ViewModels;

namespace ObsidianUI.Examples.Views;

public partial class StarRatingPage : ContentPage
{
	public StarRatingPage()
	{
		InitializeComponent();
		txtStarsColor.Text = "d5b23d";
	}

	private void StarColor_TextChange(object? sender, TextChangedEventArgs e)
	{
		if (sender is Entry entry)
		{
			starRating.StarsColor = Color.TryParse(entry.Text, out var color) ? color : Colors.Gold;
		}
	}

	private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		if (sender is Entry entry && entry.Text != string.Empty)
		{
			starRating.Rate = entry.Text == string.Empty ? 0 : Convert.ToInt32(entry.Text);
		}
	}

	private void TxtSpeed_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		if (sender is Entry entry && entry.Text != string.Empty)
		{
			starRating.Speed = entry.Text == string.Empty ? 0 : Convert.ToInt32(entry.Text);
		}
	}
}