using System.Linq;
using System.Text.RegularExpressions;

namespace Tiririt.Core.Extensions
{
    public static class StringExtensions 
    {
        public static string[] ParseTags(this string value, string identifier)
        {
            var pattern = $"\\{identifier}[\\^a-zA-Z]+";
            var result = Regex.Matches(value, pattern)
                .Cast<Match>()
                .Select(m => m.Value.Remove(0, 1))
                .ToArray();
            return result;
        }        
    }
}