using System.Reflection;

namespace TJC.AssemblyExtensions.Attributes;

public static class CommonAttributesExtensions
{
    public static string GetTitle(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
}