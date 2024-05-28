using System.Reflection;
using Serializer.Interfaces;

namespace Serializer.Services;

public class ReflectionSerializer<T> : ISerializer<T> where T : new()
{
    public string Serialize(T obj)
    {
        if (obj == null) 
            throw new ArgumentNullException($"Got empty object.");

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

        var serializedProperties = properties.Select(p => $"{p.Name}={p.GetValue(obj)}");
        var serializedFields = fields.Select(f => $"{f.Name}={f.GetValue(obj)}");

        return string.Join(",", serializedProperties.Concat(serializedFields));
    }
    
    public T Deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data)) 
            throw new ArgumentNullException($"Empty. So empty... ");

        var obj = new T();
        var keyValuePairs = data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split('='))
            .ToDictionary(split => split[0], split => split[1]);

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            if (keyValuePairs.TryGetValue(property.Name, out var value))
                property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
        }

        foreach (var field in fields)
        {
            if (keyValuePairs.TryGetValue(field.Name, out var value))
                field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
        }

        return obj;
    }
}