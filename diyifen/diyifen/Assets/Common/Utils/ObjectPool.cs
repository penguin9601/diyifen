using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : new()
{
    List<T> _pool;

	public ObjectPool()
    {
        _pool = new List<T>();
    }

    public T Get()
    {
        T ret = default(T);
        if (_pool.Count > 0)
        {
            ret = _pool[0];
            _pool.RemoveAt(0);
        }
        else
        {
            ret = new T();
        }

        return ret;
    }
    

    public void Add(T obj)
    {
        _pool.Add(obj);
    }
}
