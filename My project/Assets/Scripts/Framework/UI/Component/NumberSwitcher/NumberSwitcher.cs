using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NumberSwitcher : UICollector
{
    [SerializeField] private int maxNumber = 4;
    [SerializeField] private int minNumber = 1;
    private int _currentNumber = 1;
    public UnityEvent<int> onValueChanged;

    public int GetCurrentValue() { return _currentNumber; }
    private void InitUIs()
    {
        Get<Button>("AddButton").onClick.AddListener(() =>
        {
            if (_currentNumber >= maxNumber) return;
            _currentNumber ++;
            onValueChanged?.Invoke(_currentNumber);
        });
        
        Get<Button>("MinusButton").onClick.AddListener(() =>
        {
            if (_currentNumber <= minNumber) return;
            _currentNumber --;
            onValueChanged?.Invoke(_currentNumber);
        });
    }

    void UpdateNumber(int value = 1)
    {
        Get<Text>("NumberText").text = value.ToString();
    }

    protected override void Awake()
    {
        base.Awake();
        InitUIs();
        onValueChanged.AddListener(UpdateNumber);
        UpdateNumber();
    }
}
