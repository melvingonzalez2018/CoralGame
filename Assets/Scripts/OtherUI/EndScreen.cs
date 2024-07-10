using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject coralPercent;
    [SerializeField] GameObject newDiveButton;
    [SerializeField] GameObject endSceneButton;
    public void EndSceneObjects() {
        coralPercent.SetActive(true);
        newDiveButton.SetActive(false);
        endSceneButton.SetActive(true);
    }
}
