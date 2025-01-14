using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to control the effects interactions
public class PlayerEffectController : MonoBehaviour
{
    RotateWobble rotate;
    ScaleWobble scale;

    private void Start() {
        rotate = GetComponent<RotateWobble>();
        scale = GetComponent<ScaleWobble>();
    }

    public void ScaleWobble() {
        rotate.enabled = false;
        scale.ActivateWobble(CompleteWobble);
    }

    public void CompleteWobble() {
        rotate.enabled = true;
    }
}
