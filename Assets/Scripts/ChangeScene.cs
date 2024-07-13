using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] bool clickToChangeScene = false;
    [SerializeField] string sceneName;

    private void Update() {
        if(Input.GetMouseButtonDown(0) && clickToChangeScene) {
            StartChangeScene(sceneName);
        }
    }
    public void StartChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
