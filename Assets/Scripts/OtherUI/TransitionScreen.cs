using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour {
    [SerializeField] float transitionDuration;
    [SerializeField] Image screen;
    [SerializeField] AnimationCurve curve;
    [SerializeField] UnityEvent OnStart;
    [SerializeField] UnityEvent OnMidTransition;
    [SerializeField] UnityEvent OnEndTransition;
    [SerializeField] bool startOnStart;
    UnityAction OnEndAction;
    float timer = 0;
    bool executeMidTransition = false;
    bool transitionActive = false;

    private void Start() {
        if (startOnStart) {
            OnStart.Invoke();
            StartTransitionHalf();
        }
        else { 
            EndTransition(); 
        }
    }

    private void Update() {
        if(timer <= transitionDuration && transitionActive) {
            timer += Time.deltaTime;

            // Setting color
            Color setColor;
            float halfDuration = transitionDuration / 2;
            setColor = new Color(0, 0, 0, curve.Evaluate(timer / halfDuration));
            screen.color = setColor;

            if (!executeMidTransition && timer >= halfDuration) {
                OnMidTransition.Invoke();
                executeMidTransition = true;
            }

            // Ending transition
            if (timer >= transitionDuration) {
                if (OnEndAction != null) {
                    OnEndAction.Invoke();
                }
                EndTransition();
            }
        }
    }
    public void EndTransition() {
        OnEndTransition.Invoke();
        gameObject.SetActive(false);
        transitionActive = false;
    }

    public void StartTransition() {
        gameObject.SetActive(true);
        transitionActive = true;
        timer = 0;
        executeMidTransition = false;
    }
    public void StartTransitionHalf() {
        gameObject.SetActive(true);
        transitionActive = true;
        timer = transitionDuration/2;
        executeMidTransition = false;
    }
}
