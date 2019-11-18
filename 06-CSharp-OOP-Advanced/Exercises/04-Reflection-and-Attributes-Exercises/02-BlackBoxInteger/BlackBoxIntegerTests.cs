namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            //Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == "BlackBoxInteger");

            var instance = Activator.CreateInstance(type, true);
            //var ctrs = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            //var ctr = ctrs.FirstOrDefault(c => c.GetParameters().Any(p => p.ToString().StartsWith("Int32")));            
            //var instance = ctr.Invoke(new object[] { 0 });

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                int value = int.Parse(inputArgs[1]);

                var method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);

                method.Invoke(instance, new object[] { value });

                var innerValue = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                Console.WriteLine(innerValue.GetValue(instance));

                input = Console.ReadLine();
            }
        }
    }
}
