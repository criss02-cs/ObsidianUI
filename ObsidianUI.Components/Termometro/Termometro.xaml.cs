
namespace ObsidianUI.Components.Termometro;

public partial class Termometro : ContentView
{
    public static BindableProperty TemperaturaProperty =
        BindableProperty.Create(nameof(Temperatura), typeof(double), typeof(Termometro), 0.0,
            propertyChanged: TemperaturaPropertyChanged);

    public static BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(double), typeof(Termometro), 0.0,
            propertyChanged: MaxValuePropertyChanged);

    public static BindableProperty SpeedProperty =
        BindableProperty.Create(nameof(Speed), typeof(int), typeof(Termometro), 0);

    public static BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(Termometro), Color.FromRgba("#333"),
            propertyChanged: BorderColorPropertyChanged);

    public static BindableProperty TemperaturaColorProperty =
        BindableProperty.Create(nameof(TemperaturaColor), typeof(Color), typeof(Termometro), Colors.Red,
            propertyChanged: BorderColorPropertyChanged);

    private static void BorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not Termometro control) return;
    }

    private static void MaxValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not Termometro control) return;
        control.Animate();
    }

    private static void TemperaturaPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not Termometro control) return;
        var temperatura = Convert.ToDouble(newvalue);
        control.label.Text = $"{temperatura}�C";
        control.Animate();
    }

    public double Temperatura { get => (double)GetValue(TemperaturaProperty); set => SetValue(TemperaturaProperty, value); }
    public double MaxValue { get => (double)GetValue(MaxValueProperty); set => SetValue(MaxValueProperty, value); }
    public int Speed { get => (int)GetValue(SpeedProperty); set => SetValue(SpeedProperty, value); }
    public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }
    public Color TemperaturaColor { get => (Color)GetValue(TemperaturaColorProperty); set => SetValue(TemperaturaColorProperty, value); }
    public Termometro()
    {
        InitializeComponent();
        Animate();
    }

    private void Animate()
    {
        if (this.AnimationIsRunning("animation"))
        {
            this.AbortAnimation("animation");
        }
        var h = (Temperatura / MaxValue) * scavo.Height;
        var anim = new Animation
        {
            { 0, 1, new Animation(v => path.TranslationY = v, path.TranslationY, h * -1) },
            { 0, 1, new Animation(v => barratemperatura.HeightRequest = v, barratemperatura.Height, h) },
        };
        anim.Commit(this, "animation", 16U, Convert.ToUInt32(Speed), Easing.SinOut);
    }

    private void Termometro_OnParentChanged(object? sender, EventArgs e)
    {
        Animate();
    }
}