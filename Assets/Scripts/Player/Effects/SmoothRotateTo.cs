using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotateTo : MonoBehaviour
{
    [SerializeField] public Transform affectedTransform;
    [SerializeField] [Range(0f, 1f)] float smoothMag;
    public Vector3 targetDirection;

    private void Update() {
        affectedTransform.forward = Vector3.Lerp(affectedTransform.forward, targetDirection, smoothMag);
    }

    public void SetTargetDirection(Vector3 target) {
        if(target == Vector3.zero) return;
        targetDirection = target;
    }
}
