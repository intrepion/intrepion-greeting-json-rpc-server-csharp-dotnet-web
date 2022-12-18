namespace greeting_tests;

public class GreetingTests
{
    [Theory]
    [InlineData("Oliver", "Hello, Oliver!")]
    [InlineData("", "Hello, World!")]
    [InlineData("😊", "Hello, 😊!")]
    public void HappyPaths(string name, string expected)
    {
        var actual = Greeter.Greet(name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(" Oliver   \n", "Hello, Oliver!")]
    [InlineData("  \t  \r", "Hello, World!")]
    [InlineData("\n😊\n😊", "Hello, 😊\n😊!")]
    public void UnhappyPaths(string name, string expected)
    {
        var actual = Greeter.Greet(name);

        Assert.Equal(expected, actual);
    }
}
