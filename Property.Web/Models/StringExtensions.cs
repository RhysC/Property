using System.Text.RegularExpressions;

namespace Property.Web.Models
{
    public static class StringExtensions
    {
        public static string ToSeperatedWords(this string value)
        {
            return value == null ? 
                       null : 
                       Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim();
        }
    }
}