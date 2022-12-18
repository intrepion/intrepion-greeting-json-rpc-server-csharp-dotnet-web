public class Greeter
{
    public static string Greet(string name)
    {
        if (name == "") {
            name = "World";
        }

        return $"Hello, {name}!";
    }
}
