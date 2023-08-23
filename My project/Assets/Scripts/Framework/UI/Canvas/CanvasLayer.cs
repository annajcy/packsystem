using UnityEngine;
using UnityEngine.UI;

public class CanvasLayer
{
    private BaseCanvas _canvas;
    public RectTransform Root;
    public RectTransform Bottom;
    public RectTransform Middle;
    public RectTransform Top;
    public RectTransform System;

    public CanvasLayer(BaseCanvas baseCanvas)
    {
        _canvas = baseCanvas;
        SetLayers();
    }

    private void SetLayers()
    {
        RectTransform root = _canvas.transform as RectTransform;
        Root = root;
        if (root != null)
        {
            Bottom = GetLayer("Bottom");
            Middle = GetLayer("Middle");
            Top = GetLayer("Top");
            System = GetLayer("System");
        }
    }

    private RectTransform GetLayer(string name)
    {
        var transform = Root.Find(name);
        Helper.FitResolution(transform.GetComponent<AspectRatioFitter>(), _canvas.GetAspectRatio());
        transform.SetParent(Root);
        return transform as RectTransform;
    }
}