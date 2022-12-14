namespace greeting_tests;

public class GreetingTests
{
    [Theory]
    [InlineData("Oliver", "Hello, Oliver!")]
    [InlineData("", "Hello, World!")]
    [InlineData("š", "Hello, š!")]
    public void HappyPaths(string name, string expected)
    {
        var actual = Greeter.Greet(name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(" Oliver   \n", "Hello, Oliver!")]
    [InlineData("  \t  \r", "Hello, World!")]
    [InlineData("\nš\nš", "Hello, š\nš!")]
    public void UnhappyPaths(string name, string expected)
    {
        var actual = Greeter.Greet(name);

        Assert.Equal(expected, actual);
    }
}
