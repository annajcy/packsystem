using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    protected override void OnButtonClick(string buttonName)
    {
        base.OnButtonClick(buttonName);
        if (buttonName == "Pack")
        {
            PanelManager.Instance().Hide<StartPanel>();
            PanelManager.Instance().Show<PackPanel>();
        }
        else if (buttonName == "Store")
        {
            PanelManager.Instance().Hide<StartPanel>();
            PanelManager.Instance().Show<StorePanel>();
        }
    }
}
