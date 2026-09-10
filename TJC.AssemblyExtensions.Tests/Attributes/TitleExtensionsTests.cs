namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class TitleExtensionsTests
{
    [TestMethod]
    public void AssemblyTitle()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetTitle();

        // Assert
        Assert.AreEqual("TJC.AssemblyExtensions.Tests", result);
    }

    [TestMethod]
    public void AssemblyTitle_WhenAttributeIsMissing_ReturnsEmptyString()
    {
        var assembly = System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName("TitleWithoutAttribute"),
            System.Reflection.Emit.AssemblyBuilderAccess.Run
        );

        var result = assembly.GetTitle();

        Assert.AreEqual(string.Empty, result);
    }
}
