using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StorePanel : ItemPanel<StorePanel>
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
        if (buttonName == "ItemBuyButton")
        {
            EventManager.Instance().EventTrigger(Message.ItemBuy, GetItemOperation());
            return;
        }
    }
}
