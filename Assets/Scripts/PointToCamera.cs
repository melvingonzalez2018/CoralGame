using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCamera : MonoBehaviour
{


    private void PointToCameraUpdate() {
        Vector3 pointToCam = Camera.main.gameObject.transform.position - transform.position;
        transform.forward = -pointToCam.normalized;
    }

    private void OtherPointToCameraUpdate() {
        transform.forward = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        OtherPointToCameraUpdate();
    }
}
