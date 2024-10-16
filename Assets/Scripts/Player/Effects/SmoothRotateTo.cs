using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotateTo : MonoBehaviour
{
    [SerializeField] Transform affectedTransform;
    [SerializeField] [Range(0f, 1f)] float smoothMag;
    Vector3 targetDirection;

    private void Update() {
        affectedTransform.forward = Vector3.Lerp(affectedTransform.forward, targetDirection, smoothMag);
    }

    public void SetTargetDirection(Vector3 target) {
        targetDirection = target;
    }
}
