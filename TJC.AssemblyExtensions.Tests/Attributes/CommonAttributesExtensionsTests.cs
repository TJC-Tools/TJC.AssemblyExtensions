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
    }
}