using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickScale : MonoBehaviour
{
    public float scaleDown = 0.75f;
    MyJuice[] juices;

    private void Start() {
        juices = FindObjectsOfType<MyJuice>();
    }


    public void ScaleDown() {
        Debug.Log("Down");
        foreach (MyJuice juice in juices) {
            juice.Cancel();
        }
        transform.localScale = new Vector3 (scaleDown, scaleDown, scaleDown);
    }

    public void ScaleNormal() {
        Debug.Log("Normal");
        transform.localScale = new Vector3(1, 1, 1);
    }
}
