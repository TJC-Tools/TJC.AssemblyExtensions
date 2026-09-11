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

    [TestMethod]
    public void AssemblyChangelogIncludeUnreleasedSection_PreservesEmptySectionByDefault()
    {
        var contents = Assembly.GetExecutingAssembly().GetChangelog(
            includeUnreleasedSection: true
        );

        StringAssert.Contains(contents, "## Unreleased");
    }

    [TestMethod]
    public void AssemblyChangelogExcludeUnreleasedSectionWhenEmpty_RemovesEmptySection()
    {
        var contents = Assembly.GetExecutingAssembly().GetChangelog(
            includeUnreleasedSection: true,
            excludeUnreleasedSectionWhenEmpty: true
        );

        Assert.IsFalse(contents.Contains("## [Unreleased]"));
    }

    [TestMethod]
    public void AssemblyChangelogExcludeUnreleasedSectionWhenEmpty_DoesNothingWhenSectionExcluded()
    {
        var contents = Assembly.GetExecutingAssembly().GetChangelog(
            excludeUnreleasedSectionWhenEmpty: true
        );

        Assert.IsFalse(contents.Contains("## [Unreleased]"));
    }

    [TestMethod]
    public void RemoveEmptyUnreleasedSection_WhenSectionHasContent_PreservesSection()
    {
        var method = typeof(ChangelogExtensions).GetMethod(
            "RemoveEmptyUnreleasedSection",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static
        );

        var result = method!.Invoke(
            null,
            ["## [Unreleased]\r\n\r\n### Added\r\n\r\n- New feature\r\n## [1.0.0]"]
        );

        StringAssert.Contains((string)result!, "## [Unreleased]");
        StringAssert.Contains((string)result!, "- New feature");
    }

    [TestMethod]
    public void AssemblyChangelog_WhenResourceIsMissing_ReturnsEmptyString()
    {
        var result = typeof(object).Assembly.GetChangelog();

        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void RemoveHeader_WhenMarkerIsMissing_ReturnsOriginalText()
    {
        var method = typeof(ChangelogExtensions).GetMethod(
            "RemoveHeader",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static
        );

        var result = method!.Invoke(null, ["plain text"]);

        Assert.AreEqual("plain text", result);
    }

    [TestMethod]
    public void MovePathsToHeaders_WhenHeaderHasNoPath_PreservesHeader()
    {
        var method = typeof(ChangelogExtensions).GetMethod(
            "MovePathsToHeaders",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static
        );

        var result = method!.Invoke(null, ["## [1.0.0]\r\nplain text"]);

        StringAssert.Contains((string)result!, "## [1.0.0]");
        StringAssert.Contains((string)result!, "plain text");
    }
}
