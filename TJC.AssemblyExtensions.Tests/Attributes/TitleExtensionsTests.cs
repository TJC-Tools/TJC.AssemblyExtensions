namespace TJC.AssemblyExtensions.Tests.Attributes;


public class TitleExtensionsTests
{
    [Fact]
    public void AssemblyTitle()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetTitle();

        // Assert
        Assert.Equal("TJC.AssemblyExtensions.Tests", result);
    }

    [Fact]
    public void AssemblyTitle_WhenAttributeIsMissing_ReturnsEmptyString()
    {
        var assembly = System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName("TitleWithoutAttribute"),
            System.Reflection.Emit.AssemblyBuilderAccess.Run
        );

        var result = assembly.GetTitle();

        Assert.Equal(string.Empty, result);
    }
}
