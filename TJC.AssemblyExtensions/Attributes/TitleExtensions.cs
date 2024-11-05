namespace TJC.AssemblyExtensions.Attributes;

/// <summary>
/// Extensions for title attribute.
/// </summary>
public static class TitleExtensions
{
    /// <summary>
    /// Get the assembly's title.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetTitle(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
}
