using System;
using System.Globalization;

namespace ZPLForge.Common
{
    /// <summary>
    /// Wide bar to narrow bar distance
    /// </summary>
    public sealed class BarDistance
    {
        public static BarDistance Ratio20 = new BarDistance(2.0);
        public static BarDistance Ratio21 = new BarDistance(2.1);
        public static BarDistance Ratio22 = new BarDistance(2.2);
        public static BarDistance Ratio23 = new BarDistance(2.3);
        public static BarDistance Ratio24 = new BarDistance(2.4);
        public static BarDistance Ratio25 = new BarDistance(2.5);
        public static BarDistance Ratio26 = new BarDistance(2.6);
        public static BarDistance Ratio27 = new BarDistance(2.7);
        public static BarDistance Ratio28 = new BarDistance(2.8);
        public static BarDistance Ratio29 = new BarDistance(2.9);
        public static BarDistance Ratio30 = new BarDistance(3.0);

        private BarDistance(double ratio)
        {
            Ratio = ratio;
        }

        public double Ratio { get; }

        public static explicit operator double (BarDistance distance) => distance.Ratio;

        public static BarDistance Parse(string ratio)
        {
            if (!double.TryParse(ratio, NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
                throw new ArgumentException($"A floating number was expected. Instead received: '{ratio}'.");

            if (num < 2.0 || num > 3.0)
                throw new ArgumentOutOfRangeException("Ratio must be in a range between 2.0 and 3.0");

            return new BarDistance(num);
        }
    }
}
