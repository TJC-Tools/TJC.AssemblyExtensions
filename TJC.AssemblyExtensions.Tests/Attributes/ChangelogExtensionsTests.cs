namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class ChangelogExtensionsTests
{
    private const string ChangelogStart =
        "# Changelog\r\n\r\n"
        + "All notable changes to this project will be documented in this file.\r\n\r\n"
        + "The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),\r\n"
        + "and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).";

    private const string ChangelogPath =
        "https://github.com/TJC-Tools/TJC.AssemblyExtensions/compare/";

    [TestMethod]
    public void AssemblyChangelogStart()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var contents = assembly.GetChangelog(includeHeader: true);
        var result =
            contents.StartsWith(ChangelogStart)
            || contents.StartsWith(ChangelogStart.Replace("\r", string.Empty));

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AssemblyChangelogIncludePath()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var contents = assembly.GetChangelog(includePaths: true);
        var result = contents.Contains(ChangelogPath);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AssemblyChangelogExcludePath()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var contents = assembly.GetChangelog(includePaths: false);
        var result = contents.Contains(ChangelogPath);

        // Assert
        Assert.IsFalse(result);
    }
}
