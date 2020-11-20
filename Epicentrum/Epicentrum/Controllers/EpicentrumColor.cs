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
            const double avgMagnitude = 4.5;
            int red = 255;
            int green = 0;

            if (magnitude < avgMagnitude)
                green = (int)(maxRGB - maxRGB / avgMagnitude * magnitude);
            else
                red = (int)(maxRGB - maxRGB / avgMagnitude * (magnitude-avgMagnitude));

            Color color = Color.FromArgb(red, green, minRGB);
            return ColorTranslator.ToHtml(color);
        }
    }
}
