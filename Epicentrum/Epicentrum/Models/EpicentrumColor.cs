using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class EpicentrumColor
    {
        private const double maxMagnitude = 9;
        private const double minMagnitude = 0;
        private const double avgMagnitude = maxMagnitude / 2;
        private const int maxRGB = 255;
        private const int minRGB = 0;

        public static string FromMagnitude(double? magnitude)
        {
            double normalizedMagnitude = Normalize(magnitude);
            int red = 255;
            int green = 0;

            if (normalizedMagnitude < avgMagnitude)
                green = (int)(maxRGB - maxRGB / avgMagnitude * normalizedMagnitude);
            else
                red = (int)(maxRGB - maxRGB / avgMagnitude * (normalizedMagnitude - avgMagnitude));

            Color color = Color.FromArgb(red, green, minRGB);
            return ColorTranslator.ToHtml(color);
        }

        public static double Normalize(double? magnitude) => magnitude switch
        {
            double m when m >= minMagnitude && m <= maxMagnitude => m,
            double m when m < minMagnitude => minMagnitude,
            double m when m > maxMagnitude => maxMagnitude,
            _ => minMagnitude
        };
    }
}
