using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class EpicentrumColor
    {
        public static string FromMagnitude(double? magnitude)
        {
            const int maxRGB = 255;
            const int minRGB = 0;
            const double magnitudeAverage = 4.5;
            int red = 255;
            int green = 0;

            if (magnitude < magnitudeAverage)
                green = (int)(maxRGB - maxRGB / magnitudeAverage * magnitude);
            else
                red = (int)(maxRGB - maxRGB / magnitudeAverage * (magnitude-magnitudeAverage));

            Color color = Color.FromArgb(red, green, minRGB);
            return ColorTranslator.ToHtml(color);
        }
    }
}
