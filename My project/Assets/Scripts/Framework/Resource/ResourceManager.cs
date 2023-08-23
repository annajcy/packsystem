using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : SingletonBase<ResourceManager>
{
    public static string GetUIPanelPath(string name)
    {
        return "UI/Panel/" + name;
    }
    
    public static string GetUIComponentPath(string name)
    {
        return "UI/Component/" + name;
    }

    public static string GetUICanvasPath(string name)
    {
        return "UI/Canvas/" + name;
    }
    
    public T Load<T>(string name) where T : Object
    {
        var resource = Resources.Load<T>(name);
        resource.name = name;
        return resource is GameObject ? Object.Instantiate(resource) : resource;
    }
    
    public T Load<T>(string name, string rename) where T : Object
    {
        var resource = Resources.Load<T>(name);
        resource.name = rename;
        return resource is GameObject ? Object.Instantiate(resource) : resource;
    }
    
    public void LoadAsync<T>(string name, UnityAction<T> action) where T : Object
    {
        MonoManager.Instance().StartCoroutine(LoadAsyncReal(name, action));
    }

    private IEnumerator LoadAsyncReal<T>(string name, UnityAction<T> action) where T : Object
    {
        var request = Resources.LoadAsync<T>(name);
        yield return request;

        if (request.asset is GameObject)
        {
            var gameObject = Object.Instantiate(request.asset) as T;
            gameObject.name = name;
            action.Invoke(gameObject);
        }
        else 
            action.Invoke(request.asset as T);
    }
    
    public void LoadAsync<T>(string name, string rename, UnityAction<T> action) where T : Object
    {
        MonoManager.Instance().StartCoroutine(LoadAsyncReal(name, rename, action));
    }

    private IEnumerator LoadAsyncReal<T>(string name, string rename, UnityAction<T> action) where T : Object
    {
        var request = Resources.LoadAsync<T>(name);
        yield return request;

        if (request.asset is GameObject)
        {
            var gameObject = Object.Instantiate(request.asset) as T;
            gameObject.name = rename;
            action.Invoke(gameObject);
        }
        else 
            action.Invoke(request.asset as T);
    }
}