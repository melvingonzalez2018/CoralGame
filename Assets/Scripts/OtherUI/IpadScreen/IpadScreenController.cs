using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpadScreenController : MonoBehaviour
{
    [SerializeField] List<RectTransform> targets;
    [SerializeField] float transitionMag;
    int targetIndex = 0;
    RectTransform rect;

    private void Start() {
        rect = GetComponent<RectTransform>();
    }

    private void Update() {
        rect.position = Vector3.Lerp(rect.position, targets[targetIndex].position, transitionMag);
    }

    public void MoveRight() {
        targetIndex++;
        targetIndex = targetIndex % targets.Count;
    }
    public void MoveLeft() {
        targetIndex--;
        if(targetIndex < 0) { targetIndex = targets.Count - 1; }
    }
    public void ResetPosition() {
        targetIndex = 0;
    }
}
