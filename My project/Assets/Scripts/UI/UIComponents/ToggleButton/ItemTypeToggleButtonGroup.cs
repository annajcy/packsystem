using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class ItemTypeToggleButtonGroup : ToggleButtonGroup
{
    [SerializeField] private string[] labels;

    protected override void OnInit(Toggle toggleButton, int index)
    {
        base.OnInit(toggleButton, index);
        toggleButton.GetComponentInChildren<Text>().text = labels[index];
    }
}
