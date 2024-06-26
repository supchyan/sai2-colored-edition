﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S2CE.Extensions {
    static class ExS2CE {
        /// <summary>
        /// Substrings file name to add it into app list names.
        /// </summary>
        public static string PurifyName(this string file) {
            return Path.GetFileName(file).Replace(".json", "");
        }
        /// <summary>
        /// Substrings file name to add it into app list content.
        /// </summary>
        public static string PurifyContent(this string file)
        {
            file = Path.GetFileName(file).Replace(".json", "");
            return file.Length > 45 ? $"{file.Substring(0, 45)}..." : file;
        }
        /// <summary>
        /// Converts HEX address to decimal one.
        /// </summary>
        public static int GetDecimalAddress(this string hex_address)
        {
            return int.Parse(hex_address.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }
        /// <summary>
        /// Converts hex color into byte version in BGRA format.
        /// Remember, original HEX color should be ARGB as well.
        /// </summary>
        /// <param name="hex_value">#aarrggbb</param>
        /// <returns></returns>
        public static byte[] toByteColor(this string hex_value)
        {

            // RGBA in SAI2 is BGRA. Live your life with that.
            // Also... Some BGRA sequences actually is ABGR
            // and i've no fkn~ clue, how to figure it out! ^^
            return [
                ColorTranslator.FromHtml(hex_value).B,
                ColorTranslator.FromHtml(hex_value).G,
                ColorTranslator.FromHtml(hex_value).R,
                ColorTranslator.FromHtml(hex_value).A,
            ];
        }
        public static string toHEXColor(this byte[] byte_value)
        {
            return BitConverter.ToString(byte_value).Replace("-", string.Empty);
        }
        /// <summary>
        /// Removes Alpha channel from byte color. Returns byte color with no 4th channel.
        /// </summary>
        /// <param name="c">Original color</param>
        /// <returns></returns>
        public static byte[] NoAlpha(this byte[] c)
        {
            return [c[0], c[1], c[2]];
        }
        public static byte[] Reverse(this byte[] c)
        {
            return [c[2], c[1], c[0]];
        }
        public static Dictionary<string, int> ConvertToDecimalAddressDictionary(this Dictionary<string, string> dictionary)
        {
            var tmp = new Dictionary<string, int>();
            foreach (var pair in dictionary)
            {
                tmp[pair.Key] = pair.Value.GetDecimalAddress();

            }
            return tmp;
        }
        public static Dictionary<string, byte[]> ConvertToByteColorDictionary(this Dictionary<string, string> dictionary)
        {
            var tmp = new Dictionary<string, byte[]>();
            foreach (var pair in dictionary)
            {
                tmp[pair.Key] = $"#00{pair.Value.Substring(1)}".toByteColor();

            }
            return tmp;
        }
        public static Dictionary<string, byte[]> ConvertToByteColorDictionaryRGB(this Dictionary<string, string> dictionary)
        {
            var tmp = new Dictionary<string, byte[]>();
            foreach (var pair in dictionary)
            {
                tmp[pair.Key] = pair.Value.toByteColor().NoAlpha();

            }
            return tmp;
        }
    }
}
