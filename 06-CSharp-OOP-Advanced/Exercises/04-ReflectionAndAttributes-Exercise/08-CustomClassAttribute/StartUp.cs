namespace _08_CustomClassAttribute
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetCustomAttributes<CustomAttribute>().Any())
                .ToArray();

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<CustomAttribute>();

                string command = Console.ReadLine();

                while (command != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {attr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {attr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {attr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {String.Join(", ", attr.Reviewers)}");
                            break;
                    }

                    command = Console.ReadLine();
                }
            }
        }
    }
}
