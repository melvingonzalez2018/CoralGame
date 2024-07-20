using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorTransition : MonoBehaviour {
    [SerializeField] AnimationCurve curve;
    [SerializeField] Color startColor;
    [SerializeField] Image image;
    [SerializeField] float duration;
    float timer;
    Color initalColor;

    // Start is called before the first frame update
    void Start() {
        initalColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0) {
            timer -= Time.deltaTime;
            image.color = Color.Lerp(startColor, initalColor, curve.Evaluate(timer/duration)); // Lerping color on a curve
        }
        else {
            image.color = initalColor;
        }
    }
    public void TriggerColor() {
        timer = duration;
    }
}
