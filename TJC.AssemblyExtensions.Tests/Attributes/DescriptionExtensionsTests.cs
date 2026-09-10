namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class DescriptionExtensionsTests
{
    [TestMethod]
    public void AssemblyDescription()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetDescription();

        // Assert
        Assert.AreEqual("Test Description", result);
    }

    [TestMethod]
    public void AssemblyDescription_WhenAttributeIsMissing_ReturnsEmptyString()
    {
        var assembly = System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName("DescriptionWithoutAttribute"),
            System.Reflection.Emit.AssemblyBuilderAccess.Run
        );

        var result = assembly.GetDescription();

        Assert.AreEqual(string.Empty, result);
    }
}
