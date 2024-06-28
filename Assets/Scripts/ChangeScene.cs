using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
