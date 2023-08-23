using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PanelManager : SingletonBase<PanelManager>
{
    private readonly Dictionary<string, BasePanel> _panels = new();
    
    public void Show<T>(BaseCanvas parentCanvas, ECanvasLayer layer = ECanvasLayer.Middle, UnityAction<T> action = null) where T : BasePanel
    {
        string panelName = ResourceManager.GetUIPanelPath(typeof(T).Name);
        if (_panels.TryGetValue(panelName, out var panel))
        {
            if (panel.GetParentCanvas() == parentCanvas)
            {
                action?.Invoke(panel as T);
                panel.OnShow();
            }
            else
            {
                Hide<T>();
                Show<T>(parentCanvas);
            }
        }
        else
        {
            ResourceManager.Instance().LoadAsync<GameObject>(panelName, panelObj =>
            {
                var p = panelObj.GetComponent<T>();
                p.Attach(parentCanvas, layer);
                action?.Invoke(p);
                _panels.Add(panelName, p);
                p.OnShow();
            });
        }
    }
    
    public void Show<T>(ECanvasLayer layer = ECanvasLayer.Middle, UnityAction<T> action = null) where T : BasePanel
    {
        var parentCanvas = CanvasManager.Instance().GetCanvas();
        string panelName = ResourceManager.GetUIPanelPath(typeof(T).Name);
        if (_panels.TryGetValue(panelName, out var panel))
        {
            if (panel.GetParentCanvas() == parentCanvas)
            {
                action?.Invoke(panel as T);
                panel.OnShow();
            }
            else
            {
                Hide<T>();
                Show<T>(parentCanvas);
            }
        }
        else
        {
            ResourceManager.Instance().LoadAsync<GameObject>(panelName, panelObj =>
            {
                var p = panelObj.GetComponent<T>();
                p.Attach(parentCanvas, layer);
                action?.Invoke(p);
                _panels.Add(panelName, p);
                p.OnShow();
            });
        }
    }

    public void Hide<T>()
    {
        var panelName = ResourceManager.GetUIPanelPath(typeof(T).Name);
        if (!_panels.ContainsKey(panelName)) return;
        _panels[panelName].OnHide();
        Object.Destroy(_panels[panelName].gameObject);
        _panels.Remove(panelName);
    }

    public T Get<T>() where T : BasePanel
    {
        var panelName = ResourceManager.GetUIPanelPath(typeof(T).Name);
        if (_panels.TryGetValue(panelName, out var panel))
            return panel as T;
        return null;
    }
}
