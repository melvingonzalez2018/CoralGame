using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoralUI : MonoBehaviour
{
    /// <summary>
    /// TODO
    /// - point to face camera
    /// </summary>
    [SerializeField] Coral owner;
    [SerializeField] GameObject canvas;
    [SerializeField] Image fill;
    [SerializeField] TMP_Text text;
    private void Update() {
        UIUpdate();
        PointToCamera();
    }

    private void PointToCamera() {
        Vector3 pointToCam = Camera.main.gameObject.transform.position - canvas.transform.position;
        canvas.transform.forward = -pointToCam.normalized;
    }

    private void UIUpdate() {
        if (owner.pickUpTimer > 0) {
            fill.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = "Pick Up";
            if (owner.pickUpTime != 0) {
                fill.fillAmount = owner.pickUpTimer / owner.pickUpTime;
            }
        }
        else if (owner.hammerTimer > 0) {
            fill.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = "Hammer In";
            if (owner.hammerTime != 0) {
                fill.fillAmount = owner.hammerTimer / owner.hammerTime;
            }
            if (owner.hammerTimer / owner.hammerTime >= 1) {
                fill.gameObject.SetActive(false);
                text.gameObject.SetActive(false);
            }
        }
        else {
            fill.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
    }
}
