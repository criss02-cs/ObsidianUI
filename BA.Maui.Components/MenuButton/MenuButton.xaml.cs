namespace BA.Maui.Components.MenuButton;

public partial class MenuButton : ContentView
{
	private const string OPEN_MENU_ANIM_NAME = "openmenu";
	private const string CLOSE_MENU_ANIM_NAME = "openmenu";
	private Boolean isOpen;
	public MenuButton()
	{
		InitializeComponent();
	}
	private void OpenMenu()
	{
		isOpen = true;

        if (this.AnimationIsRunning(CLOSE_MENU_ANIM_NAME))
            this.AbortAnimation(CLOSE_MENU_ANIM_NAME);

        var animation = new Animation
        {
            {0,0.5, new Animation(r => bars.Rotation = r, 0, 90) },
			{0,0.5, new Animation(m => bars.WidthRequest = m, 5,25)},

			{0,1, new Animation(t => menuitem1.Opacity = t, 0,1) },
			{0,0.5, new Animation(t => menuitem1.TranslationY = t, 0,-70) },
			{0,0.5, new Animation(t => menuitem1.WidthRequest = t, 0,40) },
			{0,0.5, new Animation(t => menuitem1.HeightRequest = t, 0,40) },

			{0,1, new Animation(t => menuitem2.Opacity = t, 0,1) },
			{0,0.5, new Animation(t => menuitem2.TranslationY = t, 0,-120) },
			{0,0.5, new Animation(t => menuitem2.WidthRequest = t, 0,40) },
			{0,0.5, new Animation(t => menuitem2.HeightRequest = t, 0,40) }

        };
        animation.Commit(this, OPEN_MENU_ANIM_NAME, length: 2000, easing: Easing.SpringOut);
    }
	private void CloseMenu()
	{
		isOpen = false;

		if (this.AnimationIsRunning(OPEN_MENU_ANIM_NAME))
			this.AbortAnimation(OPEN_MENU_ANIM_NAME);

        var animation = new Animation
        {
            {0,0.5, new Animation(r => bars.Rotation = r, 90, 0) },
            {0,0.5, new Animation(m => bars.WidthRequest = m, 25,5)},

            {0,1, new Animation(t => menuitem1.Opacity = t, 1,0) },
            {0,0.5, new Animation(t => menuitem1.TranslationY = t, -70,0) },
            {0,0.5, new Animation(t => menuitem1.WidthRequest = t, 40,0) },
            {0,0.5, new Animation(t => menuitem1.HeightRequest = t, 40,0) },

            {0,1, new Animation(t => menuitem2.Opacity = t, 1,0) },
            {0,0.5, new Animation(t => menuitem2.TranslationY = t, -120,0) },
            {0,0.5, new Animation(t => menuitem2.WidthRequest = t, 40,0) },
            {0,0.5, new Animation(t => menuitem2.HeightRequest = t, 40,0) },
        };
        animation.Commit(this, CLOSE_MENU_ANIM_NAME, length: 2000, easing: Easing.SpringOut);
    }
	public void Animate()
	{
		if (isOpen)
		{
			CloseMenu();
			return;
		}

		OpenMenu();
	}

    private void mainbutton_Tapped(object sender, TappedEventArgs e)
    {
		Animate();
    }
}