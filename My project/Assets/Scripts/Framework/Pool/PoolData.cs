using System.Collections.Generic;
using UnityEngine;

public class PoolData
{
    private readonly GameObject _fatherGameObject;
    public readonly List<GameObject> PoolList;

    public PoolData(GameObject gameObject)
    {
        _fatherGameObject = new GameObject(gameObject.name)
        { transform = { parent = PoolManager.Instance().PoolGameObject.transform } };
        PoolList = new List<GameObject>();
        Push(gameObject);
    }

    public void Push(GameObject gameObject)
    {
        PoolList.Add(gameObject);
        gameObject.transform.parent = _fatherGameObject.transform;
        gameObject.SetActive(false);
    }

    public GameObject Get(Transform newTransform = null)
    {
        var gameObject = PoolList[0];
        PoolList.RemoveAt(0);
        gameObject.SetActive(true);
        gameObject.transform.parent = newTransform;
        return gameObject;
    }
}
