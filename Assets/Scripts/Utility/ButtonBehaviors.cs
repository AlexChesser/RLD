using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviors : MonoBehaviour
{

    public void AddScene(string name)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(name, LoadSceneMode.Additive));
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(name));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string name, LoadSceneMode mode = LoadSceneMode.Single) {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name, mode);
        while (!ao.isDone)
        {
            yield return null;
        }
    }
}
