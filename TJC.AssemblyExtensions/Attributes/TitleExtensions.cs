namespace TJC.AssemblyExtensions.Attributes;

public static partial class CommonAttributeExtensions
{
    public static string GetTitle(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
}