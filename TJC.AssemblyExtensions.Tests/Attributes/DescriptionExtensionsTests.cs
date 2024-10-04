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
}