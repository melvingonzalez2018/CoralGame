using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePop : MyJuice {
    public AnimationCurve curve;

    protected override void EffectUpdate(float val, float valScale) {
        float calcVal = 1+ (val * valScale);
        transform.localScale = new Vector3(calcVal, calcVal, calcVal);
    }

    protected override void ResetValue() {
        transform.localScale = new Vector3(1, 1, 1);
    }

    protected override float EaseFunction(float t) {
        return curve.Evaluate(t * 2);
    }
}
