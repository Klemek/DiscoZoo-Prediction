using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiscoZoo_Prediction
{
    /// <summary>
    /// Store many useful functions
    /// </summary>
    public static class Utils
    {

        /// <summary>
        /// A linear shade function with several colors and a position between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Color MixColors(double pos, params Color[] colors)
        {
            if (colors == null || colors.Length == 0)
                return Colors.White;
            if (colors.Length == 1 || pos <= 0)
                return colors[0];
            if (pos >= 1)
                return colors[colors.Length - 1];

            double mix = pos * (colors.Length - 1);
            int nColor = (int)mix;
            mix -= nColor;

            Color c1 = colors[nColor];
            Color c2 = colors[nColor + 1];
            

            return new Color()
            {
                A = (byte)(c2.A * mix + c1.A * (1 - mix)),
                R = (byte)(c2.R * mix + c1.R * (1 - mix)),
                G = (byte)(c2.G * mix + c1.G * (1 - mix)),
                B = (byte)(c2.B * mix + c1.B * (1 - mix)),
            };
        }

        /// <summary>
        /// Return the real dimensions of a given TextBlock
        /// </summary>
        /// <param name="textBlock"></param>
        /// <returns></returns>
        public static Size MeasureString(this TextBlock textBlock)
        {
            FormattedText formattedText = new FormattedText(
                textBlock.Text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);
            return new Size(formattedText.Width, formattedText.Height);
        }

        /// <summary>
        /// Create a map of given type and sizes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T[][] CreateMap<T>(int width, int height, T def)
        {
            T[][] map = new T[width][];
            for (int x = 0; x < width; x++)
            {
                map[x] = new T[height];
                for (int y = 0; y < height; y++)
                    map[x][y] = def;
            }
            return map;
        }

        /// <summary>
        /// Convert a binary string map into a boolean map (';' as new line delimiter)
        /// </summary>
        /// <param name="strMap"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static bool[][] StringToMap(String strMap, Char delimiter = ';')
        {
            String[] cut = strMap.Split(delimiter);
            bool[][] map = CreateMap(cut.Min(x => x.Length), cut.Length, false);

            for (int y = 0; y < cut.Length; y++)
                for (int x = 0; x < map.Length; x++)
                    map[x][y] = cut[y].ToCharArray()[x] == '1';

            return map;
        }

    }
}
