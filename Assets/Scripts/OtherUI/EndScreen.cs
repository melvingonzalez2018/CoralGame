using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject newDiveButton;
    [SerializeField] GameObject endSceneButton;
    public void EndOfLevel() {
        newDiveButton.SetActive(false);
        endSceneButton.SetActive(true);
    }
    public void EndOfDive() {
        newDiveButton.SetActive(true);
        endSceneButton.SetActive(false);
    }
}
