namespace greeting_tests;

public class GreetingTests
{
    [Theory]
    [InlineData("Oliver", "Hello, Oliver!")]
    [InlineData("", "Hello, World!")]
    public void HappyPaths(string name, string expected)
    {
        var actual = Greeter.Greet(name);

        Assert.Equal(expected, actual);
    }
}
