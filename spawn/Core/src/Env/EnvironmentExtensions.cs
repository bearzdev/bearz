using System.Text.RegularExpressions;

namespace Spawn.Env
{
    public static class EnvironmentExtensions
    {
        public static string Expand(this IEnvironmentVariables vars, string template, ExpandOptions options = ExpandOptions.All)
        {
            if (options == ExpandOptions.All || options == ExpandOptions.Windows)
            {
                template = Regex.Replace(
                    template,
                    "%([^%]+)%",
                    (Match m) =>
                    {
                        var key = m.Groups[1].Value;
                        var value = vars.Get(key);
                        if (value == null)
                            return string.Empty;

                        return value;
                    },
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }

            if (options == ExpandOptions.All || options == ExpandOptions.Linux)
            {
                template = Regex.Replace(
                    template,
                    @"\$\{([^\}]+)\}",
                    (Match m) =>
                    {
                        var key = m.Groups[1].Value;
                        var value = vars.Get(key);
                        if (value == null)
                            return string.Empty;

                        return value;
                    },
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);

                template = Regex.Replace(
                    template,
                    @"\$([A-Za-z0-9]+)",
                    (Match m) =>
                    {
                        var key = m.Groups[1].Value;
                        var value = vars.Get(key);
                        if (value == null)
                            return string.Empty;

                        return value;
                    },
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }

            return template;
        }
    }
}