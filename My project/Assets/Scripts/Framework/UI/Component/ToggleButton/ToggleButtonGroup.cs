using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class ToggleButtonGroup : UIBehaviour
{
    [SerializeField] private int toggleButtonCount;
    [SerializeField] private Toggle toggleButtonPrefab;
    private ToggleGroup _toggleGroup;
    private Toggle _selectedToggle;
    public UnityEvent<int> onSelectedChanged;

    public Toggle GetSelectedToggle() { return _selectedToggle; }

    public int GetSelectedToggleID()
    {
        if (GetSelectedToggle() == null) return -1;
        return GetSelectedToggle().GetComponent<ToggleButton>().ID;
    }
    
    public void UpdateSelectedToggle()
    {
        var updatedSelectedToggle = _toggleGroup.GetFirstActiveToggle();
        if (updatedSelectedToggle == _selectedToggle) return;
        _selectedToggle = updatedSelectedToggle;
        onSelectedChanged?.Invoke(GetSelectedToggleID());
    }

    private void InitToggleButtons()
    {
        for (int i = 0; i < toggleButtonCount; i++)
        {
            var toggleButton = Instantiate(toggleButtonPrefab, transform);
            toggleButton.name = toggleButtonPrefab.name;
            OnInit(toggleButton, i);
        }
    }

    protected virtual void OnInit(Toggle toggleButton, int index)
    {
        toggleButton.name += index;
        if (toggleButton.group != _toggleGroup) 
            toggleButton.group = _toggleGroup;
        var toggleButtonController = toggleButton.gameObject.GetComponent<ToggleButton>();
        toggleButtonController.ID = index;
        for (int i = 0; i < toggleButton.transform.childCount; i++)
        {
            var child = toggleButton.transform.GetChild(i);
            child.name += index;
        }
    }
    
    protected override void Start()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
        InitToggleButtons();
        UpdateSelectedToggle();
    }
}
