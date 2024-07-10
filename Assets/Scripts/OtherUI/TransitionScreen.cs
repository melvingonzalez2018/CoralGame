using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour {
    [SerializeField] float transitionDuration;
    [SerializeField] Image screen;
    [SerializeField] AnimationCurve curve;
    UnityAction OnEndAction;
    float timer = 0;

    private void Update() {
        if(timer <= transitionDuration) {
            timer += Time.deltaTime;

            // Setting color
            Color setColor;
            if(timer <= transitionDuration/2) {
                setColor = new Color(0, 0, 0, timer / (transitionDuration / 2));
            }
            else {
                setColor = new Color(0, 0, 0, 1-(timer / (transitionDuration / 2)));
            }
            screen.color = setColor;

            // Ending transition0
            if (timer >= transitionDuration) {
                if (OnEndAction != null) {
                    OnEndAction.Invoke();
                }
                screen.color = Color.clear;
            }
        }
    }
    public void StartTransition(UnityAction OnEndTransition = null) {
        timer = 0;
        OnEndAction = OnEndTransition;
    }
}
