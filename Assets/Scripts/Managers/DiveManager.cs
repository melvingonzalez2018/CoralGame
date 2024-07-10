using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiveManager : MonoBehaviour
{
    [SerializeField] public int numberOfDives;
    public List<UnityEvent> OnStartDiveEvents = new List<UnityEvent>();
    int currentDive = 0;

    bool firstEvent = false;

    private void Awake() {
        // Initalize dive events
        for (int i = 0; i < numberOfDives; i++) {
            OnStartDiveEvents.Add(new UnityEvent());
        }
    }

    private void Update() {
        if(!firstEvent) {
            FirstDive();
            firstEvent = true;
        }
    }

    public void FirstDive() {
        OnStartDiveEvents[currentDive].Invoke();
    }

    public int GetCurrentDive() {
        return currentDive;
    }
    // return true if a new dive is started
    public bool StartNewDive() {
        if (currentDive < numberOfDives-1) {
            currentDive++;
            OnStartDiveEvents[currentDive].Invoke();
            UpdateCoral();

            return true;
        }
        return false;
    }

    public void UpdateCoral() {
        // Update coral
        Coral[] corals = FindObjectsOfType<Coral>();
        foreach (Coral coral in corals) {
            coral.DiveStartUpdate();
        }
    }
}
