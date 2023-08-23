using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : BaseCanvas
{
    [SerializeField] private bool enableTransformTracking;
    [SerializeField] private Transform trackedTransform;
    protected override void Awake()
    {
        base.Awake();
        _canvasType = ECanvasType.WorldSpace;
        _canvas.renderMode = RenderMode.WorldSpace;
        _canvas.worldCamera = Camera.main;
    }
    
    private void Update()
    {
        if (enableTransformTracking)
            transform.SetParent(trackedTransform);
    }
}
