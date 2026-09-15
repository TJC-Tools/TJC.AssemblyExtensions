namespace TJC.AssemblyExtensions.Tests.Attributes;


public class DescriptionExtensionsTests
{
    [Fact]
    public void AssemblyDescription()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetDescription();

        // Assert
        Assert.Equal("Test Description", result);
    }

    [Fact]
    public void AssemblyDescription_WhenAttributeIsMissing_ReturnsEmptyString()
    {
        var assembly = System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName("DescriptionWithoutAttribute"),
            System.Reflection.Emit.AssemblyBuilderAccess.Run
        );

        var result = assembly.GetDescription();

        Assert.Equal(string.Empty, result);
    }
}
