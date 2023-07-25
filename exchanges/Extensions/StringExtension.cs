using System.Globalization;
using System.Text;

namespace exchanges.Extensions
{
    public static class StringExtension
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToUpper();
        }

        public static string PowerConverter(this string str)
        {
            if (str == null) return string.Empty;
            return str.Contains("E") ? decimal.Parse(str, NumberStyles.Float).ToString() : str;
        }
    }
}