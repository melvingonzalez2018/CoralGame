using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiveManager : MonoBehaviour
{
    [SerializeField] public int numberOfDives;
    public List<UnityEvent> OnStartDiveEvents = new List<UnityEvent>();
    int currentDive = 0;
    bool firstDive = true;

    private void Awake() {
        // Initalize dive events
        for (int i = 0; i < numberOfDives; i++) {
            OnStartDiveEvents.Add(new UnityEvent());
        }
    }

    private void FirstDive() {
        OnStartDiveEvents[currentDive].Invoke();
    }

    public int GetCurrentDive() {
        return currentDive;
    }
    // return true if a new dive is started
    public void StartNewDive() {
        if(firstDive) {
            FirstDive();
            firstDive = false;
        }
        else if (currentDive < numberOfDives-1) {
            currentDive++;
            OnStartDiveEvents[currentDive].Invoke();
            UpdateCoral();
        }
    }

    public bool IsLastDive() {
        return currentDive >= numberOfDives-1;
    }

    public void UpdateCoral() {
        // Update coral
        Coral[] corals = FindObjectsOfType<Coral>();
        foreach (Coral coral in corals) {
            coral.DiveStartUpdate();
        }
    }
}
