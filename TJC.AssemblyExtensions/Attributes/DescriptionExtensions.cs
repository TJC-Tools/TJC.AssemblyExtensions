namespace TJC.AssemblyExtensions.Attributes;

public static class DescriptionExtensions
{
    public static string GetDescription(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
}