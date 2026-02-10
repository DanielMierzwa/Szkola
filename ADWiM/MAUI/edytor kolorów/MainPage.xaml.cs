namespace kolorki
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            try
            {
                double r = Preferences.Get("KolorR", 0.0);
                double g = Preferences.Get("KolorG", 0.0);
                double b = Preferences.Get("KolorB", 0.0);
                set_color(r, g, b);
                set_sliders(r, g, b);
            }
            catch
            {
                set_color(0, 0, 0);
                set_sliders(0, 0, 0);
            }
        }

        private void sliderR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            load_color();
            labelR.Text = Math.Round(255 * sliderR.Value, 0).ToString();
        }

        private void sliderG_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            load_color();
            labelG.Text = Math.Round(255*sliderG.Value,0).ToString();
        }

        private void sliderB_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            load_color();
            labelB.Text = Math.Round(255 * sliderB.Value, 0).ToString();
        }

        private void load_color()
        {
            set_color(sliderR.Value, sliderB.Value, sliderG.Value);
        }
        private void set_color(double r, double g, double b)
        {
            Color color = Color.FromRgb(
                r,
                g,
                b);
            rectangle.Fill = new SolidColorBrush(color);
            Preferences.Set("KolorR", r);
            Preferences.Set("KolorG", g);
            Preferences.Set("KolorB", b);
        }

        private void reset_color(object sender, EventArgs e)
        {
            set_color(0, 0, 0);
            set_sliders(0, 0, 0);
        }

        private void random_color_set(object sender, EventArgs e)
        {
            Random rn = new Random();
            double r = rn.Next(0, 255) / 255.0;
            double g = rn.Next(0, 255) / 255.0;
            double b = rn.Next(0, 255) / 255.0;
            set_color(r,g,b);
            set_sliders(r, g, b);
        }

        private void set_sliders(double r, double g , double b)
        {
            sliderR.Value = r;
            sliderG.Value = g;
            sliderB.Value = b;
        }

    }
}
