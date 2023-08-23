using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;
    public static T Instance()
    {
        if (_instance != null) return _instance;
        var gameObject = new GameObject { name = typeof(T).ToString() };
        _instance = gameObject.AddComponent<T>();
        return _instance;
    }
}
