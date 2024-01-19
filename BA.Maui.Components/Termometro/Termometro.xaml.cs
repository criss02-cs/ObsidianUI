namespace BA.Maui.Components.Termometro;

public partial class Termometro : ContentView
{
    public static BindableProperty TemperaturaProperty =
        BindableProperty.Create(nameof(Temperatura), typeof(double), typeof(Termometro), 0.0,
            propertyChanged: TemperaturaPropertyChanged);

    public static BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(double), typeof(Termometro), 0.0);

    private static void TemperaturaPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not Termometro control) return;
        var temperatura = Convert.ToDouble(newvalue);
        control.label.Text = $"{temperatura}°C";
        control.Animate();
    }

    public double Temperatura { get => (double)GetValue(TemperaturaProperty); set => SetValue(TemperaturaProperty, value); }
    public double MaxValue { get => (double)GetValue(MaxValueProperty); set => SetValue(MaxValueProperty, value); }
    public Termometro()
    {
        InitializeComponent();
        Animate();
    }

    private void Animate()
    {
        var h = (Temperatura / MaxValue) * scavo.Height;
        var anim = new Animation
        {
            { 0, 1, new Animation(v => path.TranslationY = v, path.TranslationY, h * -1) },
            { 0, 1, new Animation(v => pippo.HeightRequest = v, pippo.Height, h) },
        };
        anim.Commit(this, "animation", 16U, 2000U, Easing.SinOut);
    }

    private void Termometro_OnParentChanged(object? sender, EventArgs e)
    {
        Animate();
    }
}