using System.Text.RegularExpressions;

namespace MVVM_play.Common
{
    public static partial class CodeValueHelper
    {
        private static readonly Regex _regex = MyRegex();

        public static string ConvertToKey(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            return _regex.Replace(input, "").ToUpper();
        }

        [GeneratedRegex("[^0-9a-zA-Z]+", RegexOptions.Compiled)]
        private static partial Regex MyRegex();
    }
}
