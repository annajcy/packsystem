using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private Toggle _toggle;
    private ToggleButtonGroup _toggleButtonGroup;
    public int ID = -1;
    void Start()
    {
        _toggle = GetComponent<Toggle>();
        _toggleButtonGroup = GetComponentInParent<ToggleButtonGroup>();
        _toggle.targetGraphic.color = _toggle.isOn ? Color.gray : Color.white;
        _toggle.onValueChanged.AddListener(isOn => { _toggle.targetGraphic.color = isOn ? Color.gray : Color.white; });
        if (_toggleButtonGroup != null) _toggle.onValueChanged.AddListener(isOn => { _toggleButtonGroup.UpdateSelectedToggle(); });
    }
}
