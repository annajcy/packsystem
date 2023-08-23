using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventData<T> : IEventData
{
    private UnityAction<T> _actions;
    public EventData(UnityAction<T> action) { _actions += action; }
    public void AddAction(UnityAction<T> action) { _actions += action; }
    public void RemoveAction(UnityAction<T> action) { _actions -= action; }
    public void Invoke(T param) { _actions?.Invoke(param); }
    public void Clear() { _actions = null; }
}

public class EventData : IEventData
{
    private UnityAction _actions;
    public EventData(UnityAction action) { _actions += action; }
    public void AddAction(UnityAction action) { _actions += action; }
    public void RemoveAction(UnityAction action) { _actions -= action; }
    public void Invoke() { _actions?.Invoke(); }
    public void Clear() { _actions = null; }
}


