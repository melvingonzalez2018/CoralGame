using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Oxygen : MonoBehaviour
{
    [SerializeField] public UnityEvent OnOxygenDuration = new UnityEvent();
    [SerializeField] public float oxygenDuration;
    [HideInInspector] public float timer = 0;
    bool runTimer = false;
    private void Start() {
        StartTime(); // Starting time for testing
    }

    private void Update() {
        if(runTimer) {
            timer = Mathf.Min(timer+Time.deltaTime, oxygenDuration);
            if(timer >= oxygenDuration) {
                OnOxygenDuration.Invoke();
                runTimer = false;
            }
        }
    }

    public void StartTime() {
        runTimer = true;
    }
}
