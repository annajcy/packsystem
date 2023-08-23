using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UICollector : UIBehaviour
{
    private readonly Dictionary<string, List<UIBehaviour>> _uiLists = new();
    
    private void Find<T>() where T : UIBehaviour
    {
        var uis = GetComponentsInChildren<T>();
        foreach (var ui in uis)
        {
            string uiName = ui.gameObject.name;
            if (_uiLists.TryGetValue(ui.gameObject.name, out var entry))
                entry.Add(ui);
            else
                _uiLists.Add(ui.gameObject.name, new List<UIBehaviour>{ui});
            OnUIAdded(ui, uiName);
        }
    }

    protected virtual void OnUIAdded(UIBehaviour ui, string uiName) {}

    protected T Get<T>(string uiName) where T : UIBehaviour
    {
        if (!_uiLists.TryGetValue(uiName, out var uiEntry)) return null;
        foreach (var ui in uiEntry)
            if (ui is T uiBehaviour) return uiBehaviour;
        return null;
    }

    private void FindAllUI()
    {
        Find<Button>();
        Find<Image>();
        Find<Text>();
        Find<Toggle>();
        Find<Slider>();
        Find<ScrollRect>();
        Find<NumberSwitcher>();
        Find<ToggleButtonGroup>();
    }

    protected override void Awake() { FindAllUI(); }
}