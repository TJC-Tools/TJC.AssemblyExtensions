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

        const string LICENSE_CONTENTS = "Copyright (c) 2024 Tyler Carrol\r\n\r\n" +
                "Permission is hereby granted, free of charge, to any person obtaining a copy of this software " +
                "and associated documentation files (the “Software”), to deal in the Software without restriction, " +
                "including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, " +
                "and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, " +
                "subject to the following conditions:\r\n\r\n" +
                "The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\r\n\r\n" +
                "THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, " +
                "INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. " +
                "IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, " +
                "TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

        [TestMethod]
        public void AssemblyLicense()
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var contents = assembly.GetLicense();
            var result = contents.StartsWith(LICENSE_CONTENTS);


            // Assert
            Assert.IsTrue(result);
        }
    }
}