
using System.Globalization;
using UnityEngine;

namespace KalendColors
{

    //from speedomon https://discussions.unity.com/t/how-can-i-use-hex-color/193712/3
    public static class ColorsFromHex
    {
        public static Color ColorFromHex(string hex)
        {
            if (hex.Length < 6)
            {
                Debug.LogWarning("Input needs a string with a length of at least 6");
            }

            var r = hex.Substring(0, 2);
            var g = hex.Substring(2, 2);
            var b = hex.Substring(4, 2);
            string alpha;
            if (hex.Length >= 8)
                alpha = hex.Substring(6, 2);
            else
                alpha = "FF";

            return new Color((int.Parse(r, NumberStyles.HexNumber) / 255f),
                            (int.Parse(g, NumberStyles.HexNumber) / 255f),
                            (int.Parse(b, NumberStyles.HexNumber) / 255f),
                            (int.Parse(alpha, NumberStyles.HexNumber) / 255f));
        }



    }

}


