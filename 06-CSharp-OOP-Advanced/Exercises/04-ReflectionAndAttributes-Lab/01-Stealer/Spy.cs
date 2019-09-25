using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFields)
    {
        StringBuilder result = new StringBuilder();

        Type type = Type.GetType(className);

        FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        result.AppendLine($"Class under investigation: {className}");

        object classInstance = Activator.CreateInstance(type, new object[] { });

        foreach (var field in allFields.Where(f => requestedFields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return result.ToString().TrimEnd();
    }
}