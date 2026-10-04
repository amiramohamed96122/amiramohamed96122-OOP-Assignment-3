
namespace src;
public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>( this IEnumerable<T> source, int pageNumber,  int pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber));
        

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize));
        }

        int start = (pageNumber - 1) * pageSize;
        int index = 0;
        int count = 0;

        foreach (var item in source)
        {
            if (index >= start && count < pageSize)
            {
                yield return item;
                count++;
            }

            if (count == pageSize)
            {
                yield break;
            }

            index++;
        }
    }

    public static T? FindById<T>(  this IEnumerable<T> source,int id) where T : IHasId
    {
        foreach (var item in source)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>( this IEnumerable<T> source) where T : IHasId
    {
        Dictionary<int, T> result = new();

        foreach (var item in source)
        {
            result.Add(item.Id, item);
        }

        return result;
    }
}