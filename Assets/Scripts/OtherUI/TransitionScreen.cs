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
    UnityAction OnEndAction;
    float timer = 0;
    bool executeMidTransition = false;

    private void Start() {
        OnStart.Invoke();
        StartTransitionHalf();
    }

    private void Update() {
        if(timer <= transitionDuration) {
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
                gameObject.SetActive(false);
            }
        }
    }

    public void StartTransition() {
        gameObject.SetActive(true);
        timer = 0;
        executeMidTransition = false;
    }
    public void StartTransitionHalf() {
        gameObject.SetActive(true);
        timer = transitionDuration/2;
        executeMidTransition = false;
    }
}
