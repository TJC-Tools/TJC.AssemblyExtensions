using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.AssemblyExtensions.Tests.Attributes
{
    [TestClass]
    public class CommonAttributesExtensionsTests
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
        public void AssemblyCopyright_DoNotReplaceSymbol()
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var result = assembly.GetCopyright(replaceCopyrightSymbolWithC: false);

            // Assert
            Assert.AreEqual("Test Copyright © 2024", result);
        }

        [TestMethod]
        public void AssemblyCopyright_ReplaceSymbolWithC()
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var result = assembly.GetCopyright(replaceCopyrightSymbolWithC: true);

            // Assert
            Assert.AreEqual("Test Copyright (C) 2024", result);
        }
    }
}