namespace TJC.AssemblyExtensions.Tests.Attributes;

[TestClass]
public class ThirdPartyLicenseExtensionsTests
{
    private const string ThirdPartyLicenseStart =
        "This project uses third-party libraries or other resources\r\n"
        + "which are used under the terms of the following license(s).\r\n\r\n"
        + "===========================================================";

    [TestMethod]
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
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AssemblyThirdPartyLicenses_WhenResourceIsMissing_ReturnsEmptyString()
    {
        var result = typeof(object).Assembly.GetThirdPartyLicenses();

        Assert.AreEqual(string.Empty, result);
    }
}
