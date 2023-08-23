using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolManager : SingletonBase<PoolManager>
{
    private readonly Dictionary<string, PoolData> _pools = new();
    public GameObject PoolGameObject;
    
    public GameObject Get(string name)
    {
        GameObject gameObject;
        if (_pools.ContainsKey(name) && _pools[name].PoolList.Count > 0) 
            gameObject = _pools[name].Get();
        else
            gameObject = ResourceManager.Instance().Load<GameObject>(name);
        
        return gameObject;
    }
    
    public void GetAsync(string name, UnityAction<GameObject> action)
    {
        if (_pools.ContainsKey(name) && _pools[name].PoolList.Count > 0) 
            action.Invoke(_pools[name].Get());
        else
            ResourceManager.Instance().LoadAsync<GameObject>(name, action.Invoke);
    }

    public void Push(GameObject gameObject)
    {
        if (PoolGameObject == null) PoolGameObject = new GameObject("PoolManager");
        if (_pools.TryGetValue(gameObject.name, out var pool)) 
            pool.Push(gameObject);
        else 
            _pools.Add(gameObject.name, new PoolData(gameObject));
    }

    public void Clear()
    {
        _pools.Clear();
        PoolGameObject = null;
    }
}
