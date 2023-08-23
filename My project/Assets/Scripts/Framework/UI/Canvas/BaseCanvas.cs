using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class BaseCanvas : MonoBehaviour
{
    protected Canvas _canvas;
    protected CanvasScaler _canvasScaler;
    protected ECanvasType _canvasType;
    private CanvasLayer _canvasLayer;

    public float GetAspectRatio() { return ((RectTransform)transform).sizeDelta.x / ((RectTransform)transform).sizeDelta.y; }

    public ECanvasType GetCanvasType() { return _canvasType; }
    public CanvasLayer GetCanvasLayer() { return _canvasLayer; }
    public virtual void OnShow() {}
    public virtual void OnHide() {}
    
    protected virtual void Awake()
    {
        tag = "Canvas";
        OnShow();
        _canvas = GetComponent<Canvas>();
        _canvasScaler = GetComponent<CanvasScaler>();
        _canvasLayer = new CanvasLayer(this);
    }

}