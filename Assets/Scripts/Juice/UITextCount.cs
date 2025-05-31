using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UITextCount : MyJuice {
    // you need to set the valScale for the value you want to count up to
    TMP_Text text;
    public string ending = "";

    private void Start() {
        text = GetComponent<TMP_Text>();
    }

    protected override void EffectUpdate(float val, float valScale) {
        text.text = Mathf.FloorToInt(val * valScale).ToString()+ending;
    }

    protected override void ResetValue() {
        text.text = Mathf.FloorToInt(scale).ToString()+ending;
    }

    protected override float EaseFunction(float t) {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }
}
