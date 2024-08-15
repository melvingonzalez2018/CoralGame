using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {
    float highlightTimer;
    Outline outline;
    private void Start() {
        outline = GetComponent<Outline>();
    }

    public void PickUpTrash() {
        FindObjectOfType<StatTracking>().IterateTrashCollected();
        Destroy(gameObject);
    }

    private void LateUpdate() {
        highlightTimer -= Time.deltaTime;
        if (highlightTimer < 0) {
            outline.enabled = false;
        }
    }

    public void InteractHighlight() {
        highlightTimer = Time.deltaTime;
        outline.enabled = true;
    }

}
