using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : SingletonBase<SceneSwitchManager>
{
    public void Load(string name, UnityAction action)
    {
        SceneManager.LoadScene(name);
        action?.Invoke();
    }

    public void LoadAsync(string name, UnityAction action)
    {
        MonoManager.Instance().StartCoroutine(LoadAsyncReal(name, action));
    }

    private IEnumerator LoadAsyncReal(string name, UnityAction action)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(name);
        while (!asyncOperation.isDone)
        {
            EventManager.Instance().EventTrigger("LoadingUpdate", asyncOperation.progress);
            yield return asyncOperation.progress;
        }
        action?.Invoke();
    }
}