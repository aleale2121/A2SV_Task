using Xunit;
using Counter.Services;

namespace Counter.Tests.Services;

public class UnitTest1
{
    [Fact]
    public void Count_ReturnsCorrectCharacterCount()
    {
        // Arrange
        var counterService = new CounterServices();
        string input = "hello";
        Dictionary<char, int> expected = new Dictionary<char, int>
        {
            { 'h', 1 },
            { 'e', 1 },
            { 'l', 2 },
            { 'o', 1 }
        };

        // Act
        Dictionary<char, int> result = counterService.Count(input);
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Count_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        var counterService = new CounterServices();
        string input = "";
        Dictionary<char, int> expected = new Dictionary<char, int>();

        // Act
        Dictionary<char, int> result = counterService.Count(input);

        // Assert
        Assert.Equal(expected, result);
    }
}