using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageRadialFill : MyJuice {
    // you need to set the valScale for the value you want to count up to
    Image image;

    private void Start() {
        image = GetComponent<Image>();
    }

    protected override void EffectUpdate(float val, float valScale) {
        image.fillAmount = val*valScale;
    }

    protected override void ResetValue() {
        image.fillAmount = scale;
    }

    protected override float EaseFunction(float t) {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }
}
