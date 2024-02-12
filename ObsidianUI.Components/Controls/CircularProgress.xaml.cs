using System.Timers;
using Microsoft.Maui.Graphics.Text;
using ObsidianUI.Components.Drawables;
using Timer = System.Timers.Timer;

namespace ObsidianUI.Components.Controls;

public partial class CircularProgress
{
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(int),
            typeof(CircularProgress),
            10);

    public static readonly BindableProperty IncaveColorProperty =
            BindableProperty.Create(nameof(IncaveColor),
            typeof(Color),
            typeof(CircularProgress),
            Colors.Black);

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(Value),
            typeof(int),
            typeof(CircularProgress),
            100);

    public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create(nameof(ProgressColor),
            typeof(Color),
            typeof(CircularProgress),
            Colors.Purple);
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

    public static readonly BindableProperty ValueProperty =
                BindableProperty.Create(nameof(Value),
            typeof(int),
            typeof(CircularProgress),
            50);
    public static readonly BindableProperty TextProperty =
                BindableProperty.Create(nameof(Text),
            typeof(string),
            typeof(CircularProgress),
            string.Empty);

    public static readonly BindableProperty HorizontalAlignmentProperty =
        BindableProperty.Create(nameof(VerticalAlignment),
            typeof(HorizontalAlignment),
            typeof(CircularProgress),
            HorizontalAlignment.Center);

    public static readonly BindableProperty VerticalAlignmentProperty =
                BindableProperty.Create(nameof(VerticalAlignment),
            typeof(VerticalAlignment),
            typeof(CircularProgress),
            VerticalAlignment.Center);

    public static readonly BindableProperty LineCapProperty =
                BindableProperty.Create(nameof(LineCap),
            typeof(LineCap),
            typeof(CircularProgress),
            LineCap.Round);

    private readonly GraphicsView _graphicView;

    public CircularProgress()
    {
        InitializeComponent();


        _graphicView = new GraphicsView
        {
            Drawable = new CircularProgressDrawable(this)
        };

        Content = _graphicView;


        DrawTimer = new Timer(50);
        DrawTimer.Elapsed += DrawTimerElapsed;
    }

    private Timer DrawTimer { get; }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public Color IncaveColor
    {
        get => (Color)GetValue(IncaveColorProperty);
        set => SetValue(IncaveColorProperty, value);
    }

    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
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

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public HorizontalAlignment HorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
        set => SetValue(HorizontalAlignmentProperty, value);
    }
    public VerticalAlignment VerticalAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalAlignmentProperty);
        set => SetValue(VerticalAlignmentProperty, value);
    }

    public LineCap LineCap
    {
        get => (LineCap)GetValue(LineCapProperty);
        set => SetValue(LineCapProperty, value);
    }

    public void Start()
    {
        DrawTimer.Start();
    }
    public void Stop()
    {
        DrawTimer.Stop();
    }
    private void DrawTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        _graphicView.Invalidate();
    }
}