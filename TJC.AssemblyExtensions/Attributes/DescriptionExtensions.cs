namespace TJC.AssemblyExtensions.Attributes;

public static partial class CommonAttributeExtensions
{
    public static string GetDescription(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
}