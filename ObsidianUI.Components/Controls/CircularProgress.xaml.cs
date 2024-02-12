using System.Timers;
using ObsidianUI.Components.Drawables;

namespace ObsidianUI.Components.Controls;

public partial class CircularProgress
{
    public static readonly BindableProperty IncaveColorProperty =
        BindableProperty.Create(nameof(IncaveColor),
            typeof(Color),
            typeof(CircularProgress),
            Colors.Black);

    public static readonly BindableProperty ProgressColorProperty =
        BindableProperty.Create(nameof(ProgressColor),
            typeof(Color),
            typeof(CircularProgress),
            Colors.Purple);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(int),
            typeof(CircularProgress),
            10);

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value),
            typeof(int),
            typeof(CircularProgress),
            50);

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(Value),
            typeof(int),
            typeof(CircularProgress),
            100);

    public static readonly BindableProperty ProgressThicknessProperty =
        BindableProperty.Create(nameof(ProgressThickness),
            typeof(int),
            typeof(CircularProgress),
            18,
            BindingMode.TwoWay);

    public static readonly BindableProperty SpeedProperty =
        BindableProperty.Create(nameof(Speed),
            typeof(int),
            typeof(CircularProgress));

    private readonly GraphicsView _graphicView;

    public Color IncaveColor
    {
        get => (Color)GetValue(IncaveColorProperty);
        set => SetValue(IncaveColorProperty, value);
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public int ProgressThickness
    {
        get => (int)GetValue(ProgressThicknessProperty);
        set => SetValue(ProgressThicknessProperty, value);
    }

    public int Speed
    {
        get => (int)GetValue(SpeedProperty);
        set => SetValue(SpeedProperty, value);
    }

    public CircularProgress()
    {
        InitializeComponent();

        var timer = new System.Timers.Timer(500);
        timer.Elapsed += DrawTimerElapsed;
        timer.Start();

        _graphicView = new GraphicsView
        {
            Drawable = new CircularProgressDrawable(this)
        };

        Content = _graphicView;
    }

    private void DrawTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        _graphicView.Invalidate();
    }
}