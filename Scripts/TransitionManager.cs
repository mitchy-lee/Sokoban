using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public string nextSceneName;          // The name of the next scene to load

    void Start()
    {
        StartCoroutine(Hold());
    }

    IEnumerator Hold() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextSceneName);
    }
}
