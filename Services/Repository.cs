using System;

namespace MyApp;

public class Repository<T>
{
    private List<T> _data = new List<T>();

    public void Add(T t)
    {
        _data.Add(t);
    }
    public List<T> GetAll()
    {
        return _data;
    }
    public T GetById(Func<T, bool> predicate)
    {
        return _data.FirstOrDefault(predicate);
    }
}