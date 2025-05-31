using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScaleWobblePuff : MonoBehaviour {
    [SerializeField] float durationMax = 2.0f;
    [SerializeField] float scaleMag = 0.25f;
    float timer = 0;
    Vector3 intialScale = Vector3.one;
    public UnityEvent OnCompleteEffect = new UnityEvent();
    bool effectActive = false;

    public void ActivateEffect(UnityAction OnCompleteEffect = null) {
        // Setting up effect
        timer = 0;
        effectActive = true;

        // Adding effect
        if (OnCompleteEffect != null) {
            this.OnCompleteEffect.AddListener(OnCompleteEffect);
        }
    }
    public bool IsActive() {
        return effectActive;
    }

    // Update is called once per frame
    void Update() {
        if(effectActive) {
            // Iterating timer
            timer = Mathf.Min(timer + Time.deltaTime, durationMax);

            // Applying effect
            float ratio = timer / durationMax;
            if (ratio < 0.5f) {
                transform.localScale = Vector3.LerpUnclamped(intialScale, intialScale + (Vector3.one * scaleMag), EaseOutElastic(Mathf.Min(ratio*2, 1)));
            }
            else {
                transform.localScale = Vector3.LerpUnclamped(intialScale + (Vector3.one * scaleMag), intialScale, EaseInOvershoot(Mathf.Min(ratio*2-0.5f, 1)));
            }

            // Ending effect
            if(timer >= durationMax) {
                effectActive = false;
                OnCompleteEffect.Invoke();
                OnCompleteEffect.RemoveAllListeners();
            }
        }
    }

    float EaseOutElastic(float x) {
        float c4 = (2 * Mathf.PI) / 3;

        return x == 0f ? 0
            : x == 1f ? 1
            : Mathf.Pow(2, -10 * x) * Mathf.Sin((x* 10f - 0.75f) * c4) + 1;
    }

    float EaseInOvershoot(float x) {
        float c1 = 1.70158f;
        float c3 = c1 + 1f;

        return c3 * x * x * x - c1 * x * x;
    }
}
