using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject newDiveButton;
    [SerializeField] GameObject endSceneButton;
    StatTrackingUI statTrackingUI;
    EndScreenDiveSelector endScreenDiveSelector;
    private void Start() {
        statTrackingUI = GetComponentInChildren<StatTrackingUI>();
        endScreenDiveSelector = GetComponentInChildren<EndScreenDiveSelector>();
    }

    public void EndOfLevel() {
        newDiveButton.SetActive(false);
        endSceneButton.SetActive(true);
    }
    public void EndOfDive() {
        newDiveButton.SetActive(true);
        endSceneButton.SetActive(false);
    }

    public void LoadEndScreen(int diveNumber) {
        statTrackingUI.LoadStats(diveNumber);
        endScreenDiveSelector.ButtonPress(diveNumber);
        endScreenDiveSelector.UpdateInteractableButtons(diveNumber);
    }
}
