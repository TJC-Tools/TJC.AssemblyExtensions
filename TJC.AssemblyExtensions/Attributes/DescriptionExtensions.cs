namespace TJC.AssemblyExtensions.Attributes;

/// <summary>
/// Extensions for description attribute.
/// </summary>
public static class DescriptionExtensions
{
    /// <summary>
    /// Get the assembly's description.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string GetDescription(this Assembly assembly) =>
        assembly.GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
}
