public class Greeter
{
    public static string Greet(string name)
    {
        name = name.Trim();

        if (name == "") {
            name = "World";
        }

        return $"Hello, {name}!";
    }
}
