using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OcilateFade : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float frequencyFactor;
    [SerializeField] AnimationCurve animationCurve;
    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.color = new Color(1, 1, 1, animationCurve.Evaluate(timer * frequencyFactor));
    }
}
