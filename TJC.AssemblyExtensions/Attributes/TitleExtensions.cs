namespace TJC.AssemblyExtensions.Attributes;

public static class TitleExtensions
{
    public static string GetTitle(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
}