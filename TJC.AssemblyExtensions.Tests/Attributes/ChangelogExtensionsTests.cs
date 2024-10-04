namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class ChangelogExtensionsTests
{
    private const string ChangelogStart =
        "# Changelog\r\n\r\n"
      + "All notable changes to this project will be documented in this file.\r\n\r\n"
      + "The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),\r\n"
      + "and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).";

    [TestMethod]
    public void AssemblyThirdPartyLicenses()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var contents = assembly.GetChangelog();
        var result   = contents.StartsWith(ChangelogStart);

        // Assert
        Assert.IsTrue(result);
    }
}