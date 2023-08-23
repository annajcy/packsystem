using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public static class Helper
{
    [Serializable]
    public class SerializableKeyValuePair<T1, T2>
    {
        public T1 first;
        public T2 second;
    }
    
    public static GameObject CreateGameObject(GameObject gameObjectPrefab, string name, Transform parentTransform)
    {
        var gameObject = GameObject.Instantiate(gameObjectPrefab, parentTransform);
        gameObject.name = name;
        return gameObject;
    }
    
    public static GameObject CreateGameObject(GameObject gameObjectPrefab, string name)
    {
        var gameObject = GameObject.Instantiate(gameObjectPrefab);
        gameObject.name = name;
        return gameObject;
    }
    
    public static GameObject CreateGameObject(GameObject gameObjectPrefab)
    {
        var gameObject = GameObject.Instantiate(gameObjectPrefab);
        gameObject.name = gameObjectPrefab.name;
        return gameObject;
    }
    
    public static void AddEventListener(UIBehaviour ui, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger eventTrigger = ui.GetComponent<EventTrigger>();
        if (eventTrigger == null)
            eventTrigger = ui.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener(action);
        eventTrigger.triggers.Add(entry);
    }

    public static void FitResolution(AspectRatioFitter fitter, float aspectRatio)
    {
        fitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
        fitter.aspectRatio = aspectRatio;
    }
}

