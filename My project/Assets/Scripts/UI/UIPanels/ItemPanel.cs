using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class ItemPanel<T> : BasePanel where T : BasePanel
{
    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance().AddEventListener<PanelDisplayData>(Message.ReceivePanelData, PresentData);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventManager.Instance().RemoveEventListener<PanelDisplayData>(Message.ReceivePanelData, PresentData);
    }

    protected abstract void PresentData(PanelDisplayData panelDisplayData);

    protected abstract int ConvertPanelStateToItemID(PanelControllerState panelControllerState);

    private PanelControllerState GetPanelState()
    {
        return new PanelControllerState(
            Get<ItemTypeToggleButtonGroup>("ItemTypeToggleGroup").GetSelectedToggleID(),
            Get<ToggleButtonGroup>("ItemTypeToggleGroup").GetSelectedToggleID(),
            Get<NumberSwitcher>("PageSwitcher").GetCurrentValue()
        );
    }
    
    protected ItemOperation GetItemOperation(int amount = 1)
    {
        return new ItemOperation(ConvertPanelStateToItemID(GetPanelState()), amount);
    }

    protected override void OnNumberSwitcherValueChanged(string numberSwitcherName, int value)
    {
        base.OnNumberSwitcherValueChanged(numberSwitcherName, value);
        if (numberSwitcherName == "PageSwitcher")
        {
            EventManager.Instance().EventTrigger(Message.QueryPanelData, GetPanelState());
            return;
        }
    }

    protected override void OnToggleButtonGroupSelectedChanged(string toggleButtonGroupName, int toggleID)
    {
        base.OnToggleButtonGroupSelectedChanged(toggleButtonGroupName, toggleID);
        if (toggleButtonGroupName == "ItemSelectToggleGroup")
        {
            EventManager.Instance().EventTrigger(Message.QueryPanelData, GetPanelState());
            return;
        }
        
        if (toggleButtonGroupName == "ItemTypeToggleGroup")
        {
            EventManager.Instance().EventTrigger(Message.QueryPanelData, GetPanelState());
            return;
        }
    }
    
    protected override void OnButtonClick(string buttonName)
    {
        base.OnButtonClick(buttonName);
        if (buttonName == "ExitButton")
        {
            PanelManager.Instance().Hide<T>();
            PanelManager.Instance().Show<StartPanel>();
            return;
        }
    }
}
