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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N) && runTimer) {
            KillOxygen();
        }

        if (runTimer) {
            ReduceOxygen(Time.deltaTime);
        }
    }

    private void KillOxygen() {
        ReduceOxygen(float.MaxValue/2);
    }

    public void StartTime() {
        runTimer = true;
    }
    public void EndTime() {
        runTimer = false;
    }
    public void ResetTimer() {
        timer = 0;
    }

    public void ReduceOxygen(float amount) {
        timer = Mathf.Min(timer + amount, oxygenDuration);
        if (timer >= oxygenDuration) {
            runTimer = false;
            OnOxygenDuration.Invoke();
        }
    }

}
