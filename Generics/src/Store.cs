namespace src;
public interface IHasId
{
    int Id { get; }
}
public class Store<T> where T : IHasId
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T? GetById(int id)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public List<T> GetAll()
    {
        return items;
    }

    public void Remove(int id)
    {
        T? item = GetById(id);

        if (item != null)
        {
            items.Remove(item);
        }
    }
}