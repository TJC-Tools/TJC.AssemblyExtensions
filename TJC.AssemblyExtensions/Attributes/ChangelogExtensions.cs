using System.Text.RegularExpressions;
using TJC.StringExtensions.Lines;

namespace TJC.AssemblyExtensions.Attributes;

public static partial class ChangelogExtensions
{
    /// <summary>
    /// Retrieves the contents of the CHANGELOG.md file embedded in the assembly.
    /// <para>Embed the license file like so: <![CDATA[<EmbeddedResource Include="..\CHANGELOG.md"/>]]></para>
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetChangelog(
        this Assembly assembly,
        bool includeHeader = false,
        bool includeUnreleasedSection = false,
        bool includePaths = false
    )
    {
        // Read the embedded resource
        using var stream = assembly.GetManifestResourceStream(
            $"{assembly.GetName().Name}.CHANGELOG.md"
        );
        if (stream == null)
            return string.Empty;
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();

        // Header
        if (!includeHeader)
            content = RemoveHeader(content);

        // Unreleased section
        if (!includeUnreleasedSection)
            content = RemoveUnreleasedSection(content);

        // Version header paths
        if (includePaths)
            content = MovePathsToHeaders(content);
        else
        {
            content = RemovePathsFromChangelog(content);
            content = RemoveBracketsFromHeaders(content);
        }

        // Cleanup newlines
        content = content.RemoveMultipleBlankLines().Trim('\r').Trim('\n').Trim('\r');

        return content;
    }

    #region Remove Header

    private static string RemoveHeader(string changelogText)
    {
        // Define the marker we are looking for
        var marker = "## [Unreleased]";

        // Find the index of the marker
        int markerIndex = changelogText.IndexOf(marker);

        // If the marker is found, return everything starting from the marker
        if (markerIndex != -1)
            return changelogText[markerIndex..];

        // If marker is not found, return the original text
        return changelogText;
    }

    #endregion

    #region Remove Unreleased

    private static string RemoveUnreleasedSection(string changelogText)
    {
        // Define a pattern to match the Unreleased section, including all its subsections
        var unreleasedPattern = UnreleasedRegex();

        // Remove the Unreleased section by using the Regex.Replace method
        return unreleasedPattern.Replace(changelogText, "");
    }

    #endregion

    #region Remove Header Brackets

    private static string RemoveBracketsFromHeaders(string changelogText)
    {
        // Replace the headers by removing the square brackets
        return VersionHeaderToRemoveBracketsRegex().Replace(changelogText, "## $1");
    }

    #endregion

    #region Remove Paths

    private static string RemovePathsFromChangelog(string changelogText)
    {
        // Split the changelog into lines
        var changelogLines = changelogText.SplitNewLine();
        var cleanedChangelog = string.Empty;
        var urlPattern = VersionPathRegex();

        // Iterate through each line and remove lines that match the URL pattern
        foreach (var line in changelogLines)
            if (!urlPattern.IsMatch(line))
                cleanedChangelog += $"{line}{Environment.NewLine}";

        return cleanedChangelog;
    }

    #endregion

    #region Move Paths to Headers

    static string MovePathsToHeaders(string changelogText)
    {
        // Split the changelog into lines
        var changelogLines = changelogText.SplitNewLine();
        var updatedChangelog = string.Empty;
        var headerPattern = VersionHeaderRegex(); // Matches version headers like ## [0.5.0]
        var pathPattern = VersionPathRegex(); // Matches path lines like [0.5.0]: https://...

        // Dictionary to hold the paths for each version
        var pathsDictionary = new Dictionary<string, string>();

        // Process lines to collect paths and remove them from the text
        foreach (var line in changelogLines)
        {
            var pathMatch = pathPattern.Match(line);
            if (pathMatch.Success)
            {
                // Extract version and URL
                var version = pathMatch.Groups[1].Value;
                var url = pathMatch.Groups[2].Value;
                pathsDictionary[version] = url;
            }
            else
                updatedChangelog += $"{line}{Environment.NewLine}";
        }

        // Now reprocess the updated changelog and insert paths into headers
        var finalChangelog = string.Empty;
        foreach (var line in updatedChangelog.SplitNewLine())
        {
            var headerMatch = headerPattern.Match(line);
            if (headerMatch.Success)
            {
                var version = headerMatch.Groups[1].Value;
                if (pathsDictionary.TryGetValue(version, out string? value))
                    // Append the URL to the header
                    finalChangelog += $"## [{version}]({value}){Environment.NewLine}";
                else
                    finalChangelog += $"{line}{Environment.NewLine}";
            }
            else
                finalChangelog += $"{line}{Environment.NewLine}";
        }

        return finalChangelog;
    }

    #endregion

    #region Regex

    [GeneratedRegex(@"^\[(.+)\]:\s?(https?://.+)$")]
    private static partial Regex VersionPathRegex();

    [GeneratedRegex(@"^## \[([^\]]+)\]")]
    private static partial Regex VersionHeaderRegex();

    [GeneratedRegex(@"## \[Unreleased\](.*?)(?=\n## \[)", RegexOptions.Singleline)]
    private static partial Regex UnreleasedRegex();

    [GeneratedRegex(@"## \[([^\]]+)\]")]
    private static partial Regex VersionHeaderToRemoveBracketsRegex();

    #endregion
}
