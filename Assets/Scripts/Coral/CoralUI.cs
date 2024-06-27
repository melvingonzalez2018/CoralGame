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
    [SerializeField] Image fill;
    [SerializeField] TMP_Text text;
    private void Update() {
        if(owner.pickUpTimer > 0) {
            text.text = "Pick Up";
            if (owner.pickUpTime != 0) {
                fill.fillAmount = owner.pickUpTimer / owner.pickUpTime;
            }
        }
        else if(owner.hammerTimer > 0) {
            text.text = "Hammer In";
            if (owner.hammerTime != 0) {
                fill.fillAmount = owner.hammerTimer / owner.hammerTime;
            }
        }
    }
}
