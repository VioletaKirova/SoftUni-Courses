using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        var methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methodInfos)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
