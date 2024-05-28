namespace Serializer.Interfaces;

public interface ISerializer<T>
{
    string Serialize(T obj);
    
    T Deserialize(string data);
}