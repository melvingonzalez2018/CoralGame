using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLook;
    float currentX;
    float currentY;
    private void Start() {
        currentX = freeLook.m_XAxis.m_MaxSpeed;
        currentY = freeLook.m_YAxis.m_MaxSpeed;
    }

    public void SetRotationControl(bool value) {
        if(value) {
            freeLook.m_XAxis.m_MaxSpeed = currentX;
            freeLook.m_YAxis.m_MaxSpeed = currentY;
        }
        else {
            freeLook.m_XAxis.m_MaxSpeed = 0;
            freeLook.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
