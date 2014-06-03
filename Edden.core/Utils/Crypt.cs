using System;
using System.Diagnostics;
using System.Text;

namespace Edden.core.Utils
{
    public class Crypt
    {
        public static char[] Hash = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
                't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'};

        public static string GenKey(int lenght)
        {
            var hcKey = new StringBuilder();
            var random = new Random();

            for (var i = 1; i <= lenght; i++) hcKey.Append(Hash[random.Next(0, 20)]);

            return hcKey.ToString().ToLower();
        }

        public static string Encode(string str, string key)
        {
            var encode = new StringBuilder();

            encode.Append("#1");

            for (var i = 0; i < str.Length; i++)
            {
                var current = (int)str[i];
                var k = (int)key[i % key.Length];

                var encodeC1 = current / 16 + k;
                var encodeC2 = current % 16 + k;

                encode.Append(Hash[encodeC1 % Hash.Length]);
                encode.Append(Hash[encodeC2 % Hash.Length]);
            }

            return encode.ToString();

        }

        public static string Decode(string str, string key)
        {
            str = str.Substring(2);
            var decode = new StringBuilder();

            for (var i = 0; i < str.Length; i += 2)
            {
                var k = (int)key[(i / 2) % key.Length];
                var encodeC1 = GetHashIndex(str[i]);
                var encodeC2 = GetHashIndex(str[i + 1]);

                encodeC1 = 64 + encodeC1 - k;
                encodeC2 = 64 + encodeC2 - k;

                if (encodeC2 < 0)
                {
                    encodeC2 += 64;
                }

                var d = (char)(encodeC1 * 16 + encodeC2);

                decode.Append(d);
            }

            return decode.ToString();
        }

        public static int GetHashIndex(char c)
        {
            for (var i = 0; i < Hash.Length; i++)
            {
                if (Hash[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
