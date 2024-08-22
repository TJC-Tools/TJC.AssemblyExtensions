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
}