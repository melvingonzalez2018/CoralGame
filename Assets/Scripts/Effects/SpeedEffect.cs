using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedEffect : MonoBehaviour {
    [SerializeField] float durationMax = 2.0f;
    [SerializeField] float scaleMag = 0.25f;
    LinearFollowPath linearFollowPath;
    Animator animator;
    float timer = 0;
    float initalSpeed;
    public UnityEvent OnCompleteEffect = new UnityEvent();
    bool effectActive = false;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
        linearFollowPath = GetComponent<LinearFollowPath>();
        initalSpeed = linearFollowPath.speed;
    }

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
        if (effectActive) {
            // Iterating timer
            timer = Mathf.Min(timer + Time.deltaTime, durationMax);

            // Applying effect
            float ratio = timer / durationMax;
            if (ratio < 0.5f) {
                //linearFollowPath.SetSpeed(Mathf.LerpUnclamped(initalSpeed, initalSpeed * (1+scaleMag), EaseOutExpo(Mathf.Min(ratio * 2, 1))));
                animator.speed = Mathf.LerpUnclamped(1, 1 * (1 + scaleMag), EaseOutExpo(Mathf.Min(ratio * 2, 1)));
            }
            else {
                //linearFollowPath.SetSpeed(Mathf.LerpUnclamped(initalSpeed * (1+scaleMag), initalSpeed, EaseInExpo(Mathf.Min(ratio * 2 - 0.5f, 1))));
                animator.speed = Mathf.LerpUnclamped(1 * (1 + scaleMag), 1, EaseOutExpo(Mathf.Min(ratio * 2, 1)));
            }

            // Ending effect
            if (timer >= durationMax) {
                effectActive = false;
                OnCompleteEffect.Invoke();
                OnCompleteEffect.RemoveAllListeners();
            }
        }
    }

    float EaseOutExpo(float x) {
        return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
    }

    float EaseInExpo(float x) {
        return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
    }
}
