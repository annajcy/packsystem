using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        CanvasManager.Instance().UpdateCanvases();
        PanelManager.Instance().Show<StartPanel>();
    }
}
