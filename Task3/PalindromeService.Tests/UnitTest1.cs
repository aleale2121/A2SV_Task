using Palindrome.Services;
namespace PalindromeService.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("leel", true)]
    [InlineData("A man, a plan, a canal, Panama", true)]
    [InlineData("sample", false)]
    [InlineData("", true)] // Empty string is considered a palindrome
    [InlineData("4252524", true)]
    [InlineData("a4252524 A", true)]
    public void IsPalindrome_Test(string input, bool expected)
    {
        // Arrange
        var palindromeService=new PalindromeServices();

        // Act
        bool result=palindromeService.IsPalindrome(input);

        // Assert
        Assert.Equal(expected, result);
    }
}

