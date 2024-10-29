namespace TJC.AssemblyExtensions.Attributes;

public static class AttributeExtensions
{
    public static T? GetAssemblyAttribute<T>(this Assembly assembly)
        where T : Attribute => Attribute.GetCustomAttribute(assembly, typeof(T)) as T;
}
