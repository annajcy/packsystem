using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayCanvas : BaseCanvas
{
    [SerializeField] private Vector2 resolution;
    [SerializeField] private ECanvasMode canvasMode;
    protected override void Awake()
    {
        base.Awake();
        _canvasType = ECanvasType.Overlay;
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvasScaler.referenceResolution = resolution;
        if (canvasMode == ECanvasMode.Landscape) _canvasScaler.matchWidthOrHeight = 1;
        else if (canvasMode == ECanvasMode.Vertical) _canvasScaler.matchWidthOrHeight = 0;
    }
}
