using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectPool<T> : ObjectPool where T:new()
{
    Stack<T> ts = new Stack<T>();
    public T Get()
    {
        if (ts.Count > 0)
            return ts.Pop();
        else
            return new T();
    }

    public void Return(T t)
    {
        ts.Push(t);
    }

    object ObjectPool.Get()
    {
        return Get();
    }

    void ObjectPool.Return(object o)
    {
        ts.Push((T)o);
    }
}


public interface ObjectPool
{
    object Get();
    void Return(object o);
}