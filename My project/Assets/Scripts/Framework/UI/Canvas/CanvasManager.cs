using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : SingletonBase<CanvasManager>
{
    private readonly Dictionary<string, BaseCanvas> _canvases = new();

    public void Clear() { _canvases.Clear(); }

    public void UpdateCanvases()
    {
        Clear();
        var canvases = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (var canvas in canvases)
        {
            _canvases.Add(canvas.name, canvas.GetComponent<BaseCanvas>());
            GameObject.DontDestroyOnLoad(canvas);
        }
        GameObject.DontDestroyOnLoad(GameObject.Find("EventSystem"));
    }

    public BaseCanvas GetCanvas(string name = "Canvas")
    {
        return !_canvases.ContainsKey(name) ? null : _canvases[name];
    }

    public void Show(string name)
    {
        if (!_canvases.ContainsKey(name)) return;
        _canvases[name].gameObject.SetActive(true);
        _canvases[name].OnShow();
    }

    public void Hide(string name)
    {
        if (!_canvases.ContainsKey(name)) return;
        _canvases[name].gameObject.SetActive(false);
        _canvases[name].OnHide();
    }
    
}