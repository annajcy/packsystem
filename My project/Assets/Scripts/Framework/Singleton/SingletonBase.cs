using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> where T: new()
{
    private static T _instance;
    public static T Instance()
    {
        if (_instance == null)
            _instance = new T();
        return _instance;
    }
}