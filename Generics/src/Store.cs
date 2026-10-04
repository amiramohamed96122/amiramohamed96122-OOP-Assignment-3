namespace src;
public interface IHasId
{
    int Id { get; }
}
public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> items = new();

    public void Add(T item)
    {
        if (items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException(
                $"An item with Id {item.Id} already exists.");
        }

        items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {

        if (items.TryGetValue(id, out T? item))
        {
            return item;
        }

        return default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return items.Values;
    }

    public void Remove(int id)
    {
       
      items.Remove(id);
        
    }
}