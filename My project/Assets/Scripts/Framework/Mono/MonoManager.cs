using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager : SingletonMono<MonoManager>
{
    private UnityAction _updateEvent;
    private void Start() { DontDestroyOnLoad(this.gameObject); }
    private void Update() { _updateEvent?.Invoke(); }
    public void AddUpdateListener(UnityAction action) { _updateEvent += action; }
    public void RemoveUpdateListener(UnityAction action) { _updateEvent -= action; }
}


