namespace TJC.AssemblyExtensions.Attributes;

/// <summary>
/// Extensions for the LICENSE file.
/// </summary>
public static class LicenseExtensions
{
    /// <summary>
    /// Retrieves the contents of the LICENSE file embedded in the assembly.
    /// <para>Embed the license file like so: <![CDATA[<EmbeddedResource Include="..\LICENSE"/>]]></para>
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetLicense(this Assembly assembly)
    {
        using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.LICENSE");
        if (stream == null)
            return string.Empty;
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
        return content;
    }
}
