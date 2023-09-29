using System.Text.RegularExpressions;

namespace BoardsOnFireSdk;

public static partial class Regexes
{
    [GeneratedRegex("^[a-z0-9-]+$")]
    public static partial Regex DomainValidationRegex();
}