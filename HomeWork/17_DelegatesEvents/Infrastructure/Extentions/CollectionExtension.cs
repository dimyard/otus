namespace DelegatesProject.Extensions;

public static class CollectionExtension
{
    public static T GetMaximum<T>(this IEnumerable<T> collection, Func<T, float> numerezate) where T : class
    {
        if (collection == null || !collection.Any())
            return null;

        T maxElement = default;
        float maxValue = float.MinValue;

        foreach (var collectionElement in collection)
        {
            var value = numerezate(collectionElement);

            if (!(value > maxValue)) 
                continue;
            
            maxValue = value;
            maxElement = collectionElement;
        }

        return maxElement;
    }
}