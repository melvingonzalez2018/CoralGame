using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWobble : MonoBehaviour
{
    [SerializeField] SmoothRotateTo smoothRotateTo;
    [SerializeField] Transform targetTransform;
    [SerializeField] float yScaleMin = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // Calculating and finding the scale to be applied to model
        Vector3 difference = smoothRotateTo.affectedTransform.forward.normalized - smoothRotateTo.targetDirection.normalized;
        float scaleVal  = difference.magnitude;
        if(scaleVal > 0 && smoothRotateTo.targetDirection != Vector3.zero) {
            float calculatedYScale = Mathf.Lerp(1, yScaleMin, scaleVal);
            targetTransform.localScale = new Vector3(targetTransform.localScale.x, calculatedYScale, targetTransform.localScale.z);
        }
        else {
            targetTransform.localScale = new Vector3(1, 1, 1);
        }
    }
}
