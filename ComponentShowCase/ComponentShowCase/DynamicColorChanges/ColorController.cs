using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace ComponentShowCase.DynamicColorChanges
{
    public class ColorController
    {
        public string Linear_Gradient { get; set; }
        public string Radial_Gradient { get; set; }
        public EventHandler ColorChanged { get; set; }
        private CssGenerator _generator;

        public ColorController()
        {
            _generator = new();
        }

        public string GetLinearGradient(string rgbValues1, string rgbValues2)
        {
            _generator.Reset();
            _generator.AddLinearGradient(rgbValues1, rgbValues2);
            return Linear_Gradient = _generator.GetCss;
        }

        public string GetRadialGradient(string rgbValues1, string rgbValues2)
        {
            _generator.Reset();
            _generator.AddRadialGradient(rgbValues1, rgbValues2);
            _generator.AddBorder(2, "solid", "black");
            return Radial_Gradient = _generator.GetCss;
        }

        public async void Start()
        {
            Random random = new();
            while (true)
            {
                string red = random.Next(256).ToString();
                string green = random.Next(256).ToString();
                string blue = random.Next(256).ToString();
                GetLinearGradient($"{red},{green},{blue}", $"{blue},{green},{red}");
                GetRadialGradient($"{red},{green},{blue}", $"{blue},{green},{red}");
                ColorChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Linear_Gradient)));
                ColorChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Radial_Gradient)));
                await Task.Delay(100);
            }
        }
    }
}
