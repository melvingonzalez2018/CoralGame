using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class MyJuice : MonoBehaviour {
    public float duration;
    public float scale;
    public UnityEvent OnCompleteEffect = new UnityEvent();
    float timer = 0;
    bool effectActive = false;

    protected abstract void EffectUpdate(float val, float valScale);
    protected abstract float EaseFunction(float t);
    protected abstract void ResetValue();

    public void AddOnComplete(UnityAction onCompleteAction) {
        OnCompleteEffect.AddListener(onCompleteAction);
    }

    public void Activate() {
        timer = duration;
        effectActive = true;
    }

    private void Update() {
        if (effectActive) {
            timer -= Time.deltaTime;

            EffectUpdate(EaseFunction(1 - (timer / duration)), scale);

            if (timer <= 0) {
                OnCompleteEffect.Invoke();
                ResetValue();
                effectActive = false;
                timer = duration;
            }
        }
    }

}
