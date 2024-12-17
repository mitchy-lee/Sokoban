using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string nextSceneName;

    public void LoadLevel1() {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadStartScreen() {
        SceneManager.LoadScene(nextSceneName);
    }
}
