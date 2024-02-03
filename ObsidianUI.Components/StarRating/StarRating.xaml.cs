namespace ObsidianUI.Components.StarRating;

public partial class StarRating : ContentView
{
	public static BindableProperty RateProperty =
		BindableProperty.Create(nameof(Rate), typeof(int), typeof(StarRating), 0,
			propertyChanged: RatePropertyChanged);
	public static BindableProperty SpeedProperty =
		BindableProperty.Create(nameof(Speed), typeof(int), typeof(StarRating), 0);
	public static BindableProperty StarsColorProperty =
		BindableProperty.Create(nameof(StarsColor), typeof(Color), typeof(StarRating), Colors.Gold,
			propertyChanged: StarsColorPropertyChanged);

	private int _lastRate;

	private static void StarsColorPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
	{

	}

	private static void RatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
	{
		if (bindable is not StarRating control) return;
		control.RefreshStars();
	}

	public int Rate { get => (int)GetValue(RateProperty); set => SetValue(RateProperty, value); }
	public int Speed { get => (int)GetValue(SpeedProperty); set => SetValue(SpeedProperty, value); }
	public Color StarsColor { get => (Color)GetValue(StarsColorProperty); set => SetValue(StarsColorProperty, value); }
	public StarRating()
	{
		InitializeComponent();
		AnimateStars();
	}

	private void AnimateStars()
	{
		if (this.AnimationIsRunning("animation"))
		{
			this.AbortAnimation("animation");
		}

		var anim = _lastRate < Rate
			? new Animation
			{
				{ 0, 0.1, new Animation(x => s1a.Scale = x, s1a.Scale, Convert.ToInt32(Rate >= 1), Easing.BounceOut) },
				{ 0.1, 0.2, new Animation(x => s1b.Scale = x, s1b.Scale, Convert.ToInt32(Rate >= 2), Easing.BounceOut) },
				{ 0.2, 0.3, new Animation(x => s2a.Scale = x, s2a.Scale, Convert.ToInt32(Rate >= 3), Easing.BounceOut) },
				{ 0.3, 0.4, new Animation(x => s2b.Scale = x, s2b.Scale, Convert.ToInt32(Rate >= 4), Easing.BounceOut) },
				{ 0.4, 0.5, new Animation(x => s3a.Scale = x, s3a.Scale, Convert.ToInt32(Rate >= 5), Easing.BounceOut) },
				{ 0.5, 0.6, new Animation(x => s3b.Scale = x, s3b.Scale, Convert.ToInt32(Rate >= 6), Easing.BounceOut) },
				{ 0.6, 0.7, new Animation(x => s4a.Scale = x, s4a.Scale, Convert.ToInt32(Rate >= 7), Easing.BounceOut) }, 
				{ 0.7, 0.8, new Animation(x => s4b.Scale = x, s4b.Scale, Convert.ToInt32(Rate >= 8), Easing.BounceOut) }, 
				{ 0.8, 0.9, new Animation(x => s5a.Scale = x, s5a.Scale, Convert.ToInt32(Rate >= 9), Easing.BounceOut) }, 
				{ 0.9, 1, new Animation(x => s5b.Scale = x, s5b.Scale, Convert.ToInt32(Rate >= 10), Easing.BounceOut) },
			}
			: new Animation
			{
				{ 0, 0.1, new Animation(x => s5b.Scale = x, s5b.Scale, Convert.ToInt32(Rate >= 10), Easing.BounceOut) },
				{ 0.1, 0.2, new Animation(x => s5a.Scale = x, s5a.Scale, Convert.ToInt32(Rate >= 9), Easing.BounceOut) },
				{ 0.2, 0.3, new Animation(x => s4b.Scale = x, s4b.Scale, Convert.ToInt32(Rate >= 8), Easing.BounceOut) },
				{ 0.3, 0.4, new Animation(x => s4a.Scale = x, s4a.Scale, Convert.ToInt32(Rate >= 7), Easing.BounceOut) },
				{ 0.4, 0.5, new Animation(x => s3b.Scale = x, s3b.Scale, Convert.ToInt32(Rate >= 6), Easing.BounceOut) },
				{ 0.5, 0.6, new Animation(x => s3a.Scale = x, s3a.Scale, Convert.ToInt32(Rate >= 5), Easing.BounceOut) },
				{ 0.6, 0.7, new Animation(x => s2b.Scale = x, s2b.Scale, Convert.ToInt32(Rate >= 4), Easing.BounceOut) },
				{ 0.7, 0.8, new Animation(x => s2a.Scale = x, s2a.Scale, Convert.ToInt32(Rate >= 3), Easing.BounceOut) },
				{ 0.8, 0.9, new Animation(x => s1b.Scale = x, s1b.Scale, Convert.ToInt32(Rate >= 2), Easing.BounceOut) },
				{ 0.9, 1, new Animation(x => s1a.Scale = x, s1a.Scale, Convert.ToInt32(Rate >= 1), Easing.BounceOut) },
			};
		anim.Commit(this, "animation", 16U, Convert.ToUInt32(Speed));
		_lastRate = Rate;
	}

	private void RefreshStars()
	{
		AnimateStars();
	}
}