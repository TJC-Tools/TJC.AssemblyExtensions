namespace TJC.AssemblyExtensions.Attributes;

public static class ChangelogExtensions
{
    /// <summary>
    /// Retrieves the contents of the CHANGELOG.md file embedded in the assembly.
    /// <para>Embed the license file like so: <![CDATA[<EmbeddedResource Include="..\CHANGELOG.md"/>]]></para>
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetChangelog(this Assembly assembly)
    {
        using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.CHANGELOG.md");
        if (stream == null)
            return string.Empty;
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
        return content;
    }
}