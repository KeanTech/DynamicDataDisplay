namespace ComponentShowCase.DynamicColorChanges
{
    public class CssGenerator
    {
        private string _css;

        public enum Borders { solid, dotted, }

        public string GetCss { get => _css; }
        public void AddLinearGradient(string rgbValues1, string rgbValues2)
        {
            _css += $"background: linear-gradient(180deg, rgba({rgbValues1}) 20%, rgba({rgbValues2}) 40%, rgba({rgbValues2}) 60%, rgba({rgbValues1}) 80%);";
        }

        public void AddRadialGradient(string rgbValues1, string rgbValues2)
        {
            _css += $"background: radial-gradient(rgb({rgbValues1}) 20%, rgb({rgbValues2}) 80%);";
        }

        public void AddBorder(int thickness, string borderType, string color) 
        {
            _css += $"border:{thickness}px {borderType} {color};";
        }

        public void AddTextColor(string color) 
        {
            _css += $"color:{color};";
        }

        public void Reset() 
        {
            _css = "";
        }
    }
}
