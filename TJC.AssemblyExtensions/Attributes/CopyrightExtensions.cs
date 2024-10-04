using TJC.StringExtensions.Lines;

namespace TJC.AssemblyExtensions.Attributes;

public static partial class CommonAttributeExtensions
{
    public static string GetCopyright(this Assembly assembly, bool replaceCopyrightSymbolWithC = false)
    {
        var copyright = assembly.GetAssemblyAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;

        // (Optional) Replace the copyright symbol with (C)
        if (replaceCopyrightSymbolWithC)
            copyright = copyright.Replace("©", "(C)");

        // Normalize line endings
        var result = string.Empty;
        foreach (var line in copyright.SplitNewLine())
            result += $"{line.Trim()}{Environment.NewLine}";

        // Trim the trailing newline
        result = result.Trim();

        return result;
    }
}