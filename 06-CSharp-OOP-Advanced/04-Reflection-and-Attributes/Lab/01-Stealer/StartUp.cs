public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.StealFieldInfo("Hacker", "username", "password");
        System.Console.WriteLine(result);
    }
}
