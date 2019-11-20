namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {            
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == "HarvestingFields");

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            string accessModifier = Console.ReadLine();

            while (accessModifier != "HARVEST")
            {
                FieldInfo[] filteredFields = fields;

                if (accessModifier != "all")
                {
                    filteredFields = fields
                        .Where(f => f.Attributes.ToString().ToLower().Replace("family", "protected") == accessModifier)
                        .ToArray();
                }                

                foreach (var field in filteredFields)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                }

                accessModifier = Console.ReadLine();
            }
        }
    }
}
