using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(AspectRatioFitter))]
public abstract class BasePanel : UICollector
{
    private readonly Dictionary<string, List<UIBehaviour>> _uiLists = new();
    private BaseCanvas _parentCanvas;
    private ECanvasLayer _parentLayer;

    public BaseCanvas GetParentCanvas() { return _parentCanvas; }
    public ECanvasLayer GetParentLayer() { return _parentLayer; }
    
    private Transform GetParentTransform()
    {
        if (_parentLayer == ECanvasLayer.Bottom)
            return _parentCanvas.GetCanvasLayer().Bottom;
        if (_parentLayer == ECanvasLayer.Middle)
            return _parentCanvas.GetCanvasLayer().Middle;
        if (_parentLayer == ECanvasLayer.Top)
             return _parentCanvas.GetCanvasLayer().Top;
        if (_parentLayer == ECanvasLayer.System)
             return _parentCanvas.GetCanvasLayer().System;
        return null;
    }
    
    public void Attach(BaseCanvas canvas, ECanvasLayer layer)
    {
        _parentCanvas = canvas;
        _parentLayer = layer;
        Helper.FitResolution(GetComponent<AspectRatioFitter>(), canvas.GetAspectRatio());
        transform.SetParent(GetParentTransform());
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
        (transform as RectTransform).offsetMin = Vector2.zero;
        (transform as RectTransform).offsetMax = Vector2.zero;
    }
    
    protected override void OnUIAdded(UIBehaviour ui, string uiName)
    {
        if (ui is Button button)
            button.onClick.AddListener(() => { OnButtonClick(uiName); });
        else if (ui is Toggle toggle)
            toggle.onValueChanged.AddListener( val => { OnToggleValueChanged(uiName, val); });
        else if (ui is NumberSwitcher numberSwitcher)
            numberSwitcher.onValueChanged.AddListener(val => { OnNumberSwitcherValueChanged(uiName, val); });
        else if (ui is ToggleButtonGroup toggleButtonGroup)
            toggleButtonGroup.onSelectedChanged.AddListener(val => { OnToggleButtonGroupSelectedChanged(uiName, val); });
    }
    
    public virtual void OnShow()
    {
        Debug.Log("OnShow " + gameObject.name);
    }

    public virtual void OnHide()
    {
        Debug.Log("OnHide " + gameObject.name);
    }

    protected virtual void OnButtonClick(string buttonName)
    {
        Debug.Log("OnButtonClick " + buttonName);
    }

    protected virtual void OnToggleValueChanged(string toggleName, bool value)
    {
        Debug.Log("OnToggleValueChanged " + toggleName + " " + value);
    }

    protected virtual void OnNumberSwitcherValueChanged(string numberSwitcherName, int value)
    {
        Debug.Log("OnNumberSwitcherValueChanged " + numberSwitcherName + " " + value);
    }

    protected virtual void OnToggleButtonGroupSelectedChanged(string toggleButtonGroupName, int toggleID)
    {
        Debug.Log("OnToggleButtonGroupSelectedChanged " + toggleButtonGroupName + " " + toggleID);
    }
}