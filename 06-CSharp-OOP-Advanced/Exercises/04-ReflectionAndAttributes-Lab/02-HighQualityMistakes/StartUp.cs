﻿public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        System.Console.WriteLine(result);
    }
}
