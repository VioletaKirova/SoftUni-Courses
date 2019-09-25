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

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder result = new StringBuilder();

        Type type = Type.GetType(className);

        var allPublicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var allPrivateGetters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get"));
        var allPublicSetters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.StartsWith("set"));

        foreach (var field in allPublicFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (var getter in allPrivateGetters)
        {
            result.AppendLine($"{getter.Name} have to be public!");
        }

        foreach (var setter in allPublicSetters)
        {
            result.AppendLine($"{setter.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder result = new StringBuilder();

        Type type = Type.GetType(className);
        Type baseType = type.BaseType;

        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {baseType.Name}");

        var allPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in allPrivateMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder result = new StringBuilder();

        Type type = Type.GetType(className);

        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return result.ToString().TrimEnd();
    }
}