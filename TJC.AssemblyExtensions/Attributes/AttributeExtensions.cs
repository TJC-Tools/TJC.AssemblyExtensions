namespace TJC.AssemblyExtensions.Attributes;

/// <summary>
/// Extensions for assembly attributes.
/// </summary>
public static class AttributeExtensions
{
    /// <summary>
    /// Get custom attribute from assembly.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static T? GetAssemblyAttribute<T>(this Assembly assembly)
        where T : Attribute => Attribute.GetCustomAttribute(assembly, typeof(T)) as T;
}
