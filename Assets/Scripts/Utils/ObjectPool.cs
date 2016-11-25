using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectPool<T> where T:new()
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
    
}
