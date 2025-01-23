using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public abstract class CoralUI : MonoBehaviour {
    [SerializeField] GameObject canvas;
    [SerializeField] Image icon;
    //[SerializeField] TMP_Text text;
    

    
    private void Update() {
        UIUpdate();
        PointToCamera();
    }

    private void PointToCamera() {
        Vector3 pointToCam = Camera.main.gameObject.transform.position - canvas.transform.position;
        canvas.transform.forward = -pointToCam.normalized;
    }

    protected abstract bool IconCondition();

    private void UIUpdate() {
        //if (owner.IsOnReef() && !owner.IsHammeredIn()) {
        //    fill.gameObject.SetActive(true);
        //    text.gameObject.SetActive(true);
        //    text.text = "Hammer In";
        //    if (owner.hammerTime != 0) {
        //        fill.fillAmount = owner.hammerTimer / owner.hammerTime;
        //    }
        //}
        //else {
        //    fill.gameObject.SetActive(false);
        //    text.gameObject.SetActive(false);
        //}
        icon.gameObject.SetActive(IconCondition());

    }
}
