namespace TJC.AssemblyExtensions.Attributes;

/// <summary>
/// Extensions for the THIRD-PARTY-LICENSES file.
/// </summary>
public static class ThirdPartyLicenseExtensions
{
    /// <summary>
    /// Retrieves the contents of the THIRD-PARTY-LICENSES file embedded in the assembly.
    /// <para>Embed the license file like so: <![CDATA[<EmbeddedResource Include="..\THIRD-PARTY-LICENSES"/>]]></para>
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetThirdPartyLicenses(this Assembly assembly)
    {
        using var stream = assembly.GetManifestResourceStream(
            $"{assembly.GetName().Name}.THIRD-PARTY-LICENSES"
        );
        if (stream == null)
            return string.Empty;
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
        return content;
    }
}
