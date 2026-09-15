namespace TJC.AssemblyExtensions.Tests.Attributes;

public class ThirdPartyLicenseExtensionsTests
{
    private const string ThirdPartyLicenseStart =
        "This project uses third-party libraries or other resources\r\n"
        + "which are used under the terms of the following license(s).\r\n\r\n"
        + "===========================================================";

    [Fact]
    public void AssemblyThirdPartyLicenses()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var contents = assembly.GetThirdPartyLicenses();
        var result =
            contents.StartsWith(ThirdPartyLicenseStart)
            || contents.StartsWith(ThirdPartyLicenseStart.Replace("\r", string.Empty));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AssemblyThirdPartyLicenses_WhenResourceIsMissing_ReturnsEmptyString()
    {
        var result = typeof(object).Assembly.GetThirdPartyLicenses();

        Assert.Equal(string.Empty, result);
    }
}
