using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PackPanel : ItemPanel<PackPanel>
{
    protected override void PresentData(PanelDisplayData panelDisplayData)
    {
        throw new NotImplementedException();
    }

    protected override int ConvertPanelStateToItemID(PanelControllerState panelControllerState)
    {
        throw new NotImplementedException();
    }

    protected override void OnButtonClick(string buttonName)
    {
        base.OnButtonClick(buttonName);
        if (buttonName == "ItemUseButton")
        {
            EventManager.Instance().EventTrigger(Message.ItemUse, GetItemOperation());
            return;
        }
        
        if (buttonName == "ItemSellButton")
        {
            EventManager.Instance().EventTrigger(Message.ItemSell, GetItemOperation());
            return;
        }
    }
}
