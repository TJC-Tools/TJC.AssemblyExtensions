namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class CopyrightExtensionsTests
{
    [TestMethod]
    public void AssemblyCopyright_DoNotReplaceSymbol()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetCopyright(replaceCopyrightSymbolWithC: false);

        // Assert
        Assert.AreEqual($"Test Copyright © 2024{Environment.NewLine}With Multiple Lines", result);
    }

    [TestMethod]
    public void AssemblyCopyright_ReplaceSymbolWithC()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var result = assembly.GetCopyright(replaceCopyrightSymbolWithC: true);

        // Assert
        Assert.AreEqual($"Test Copyright (C) 2024{Environment.NewLine}With Multiple Lines", result);
    }
}
