using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateWobble : MyJuice
{
    protected override void EffectUpdate(float val, float valScale) {
        transform.rotation = Quaternion.Euler(0, 0, val * valScale);
    }

    protected override void ResetValue() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    protected override float EaseFunction(float t) {
        const float c4 = (2 * Mathf.PI) / 3;

        return t == 0 ? 0 :
            t == 1 ? 1 :
            Mathf.Pow(2, -5 * t) * Mathf.Sin((t * 10f) * c4);
    }
}
