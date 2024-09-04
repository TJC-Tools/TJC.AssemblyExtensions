using System.Reflection;

namespace TJC.AssemblyExtensions.Attributes;

public static class CommonAttributesExtensions
{
    public static string GetTitle(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;

    public static string GetDescription(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;

    public static string GetCopyright(this Assembly assembly, bool replaceCopyrightSymbolWithC = false)
    {
        var copyright = assembly.GetAssemblyAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;

        if (replaceCopyrightSymbolWithC)
            copyright = copyright.Replace("©", "(C)");
        return copyright;
    }

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