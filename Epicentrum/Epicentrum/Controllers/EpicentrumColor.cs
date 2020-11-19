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
            const int minRGB = 0;
            const int maxRGB = 255;
            const int numOfRanges = 9;

            int green = (int)(maxRGB - maxRGB / numOfRanges * magnitude);
            Color color = Color.FromArgb(maxRGB, green, minRGB);
            return ColorTranslator.ToHtml(color);
        }
    }
}
