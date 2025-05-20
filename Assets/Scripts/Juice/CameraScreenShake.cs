using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;

public class CameraScreenShake : MyJuice
{
    [SerializeField] CinemachineCameraOffset offset;

    private void Start() {
        offset = GetComponent<CinemachineCameraOffset>();
    }

    protected override void EffectUpdate(float val, float valScale) {
        float calculatedVal = val * valScale;
        float randomXVal = Random.Range(-calculatedVal, calculatedVal);
        float randomYVal = Random.Range(-calculatedVal, calculatedVal);
        float randomZVal = Random.Range(-calculatedVal, calculatedVal);
        offset.m_Offset = new Vector3(randomXVal, randomYVal, randomZVal);
    }

    protected override void ResetValue() {
        offset.m_Offset = new Vector3(0, 0, 0);
    }

    protected override float EaseFunction(float t) {
        return 1-(Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2)));
    }
}
